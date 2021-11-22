using System;
using System.Text;
using System.Threading;

namespace pongGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;
            drawFrame();

            int x = 132;
            int[] y = new int[] { 20, 21, 22, 23, 24, 25, 26, 27 };
            int y0 = 0;
            int direction = 0;
            drawPlayer(x, y);

            double positionXofBall = 81;
            double positionYofBall;
            int directionOfBall;

            double theta = throwBall(out positionYofBall);
            double angle = theta;
            double atheta = Math.Abs(theta);

            double pointXofBall = 0;
            double pointYofBall = 0;

            Console.SetCursorPosition(0,4);
            Console.Write("top y konumu: " + positionYofBall);


            int destroyBallX = 0;
            int destroyBallY = 0;

            double r = 4;

            Random random = new Random();
            double forReflectedAngle;

            int enemyX = 27;
            int[] enemyY = new int[] { 20, 21, 22, 23, 24, 25, 26, 27 };
            int e0 = 0;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    while (Console.KeyAvailable)
                    {
                        keyInfo = Console.ReadKey();
                    }

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:

                            if (y[0] != 6)
                            {
                                direction += 1;
                            }
                            break;

                        case ConsoleKey.DownArrow:

                            if (y[7] != 38)
                            {
                                direction -= 1;
                            }
                            break;
                    }
                }                

                if (positionYofBall - enemyY[3] > 0 && enemyY[3] != 33)
                {
                    e0 = enemyY[0];                    
                    for (int i = 0; i < enemyY.Length; i++)
                    {
                        enemyY[i] = enemyY[i] + 1;
                    }
                
                    drawEnemy(enemyX,enemyY);
                    deletePlayer(enemyX, e0);
                }

                if (positionYofBall - enemyY[3] < 0 && enemyY[3] != 9)
                {
                    e0 = enemyY[7];
                    for (int i = 0; i < enemyY.Length; i++)
                    {
                        enemyY[i] = enemyY[i] - 1;
                    }

                    drawEnemy(enemyX, enemyY);
                    deletePlayer(enemyX, e0);
                }

                Console.SetCursorPosition(0, 9);
                Console.Write(" enemy mid point: {0}", enemyY[3]);

                if (direction > 0)
                {
                    y0 = y[7];
                    direction = 0;
                    for (int i = 0; i < y.Length; i++)
                    {
                        y[i] = y[i] - 1;
                    }
                    drawPlayer(x, y);
                    deletePlayer(x, y0);
                }

                if (direction < 0)
                {
                    y0 = y[0];
                    direction = 0;
                    for (int i = 0; i < y.Length; i++)
                    {
                        y[i] = y[i] + 1;
                    }
                    drawPlayer(x, y);
                    deletePlayer(x, y0);
                }

                pointXofBall = (Math.Cos(angle) * r);
                pointYofBall = (Math.Sin(angle) * r);

                positionXofBall += pointXofBall;
                positionYofBall += pointYofBall;

                Console.SetCursorPosition(0, 2);
                Console.Write("top x konumu: {0} ", Convert.ToInt32(positionXofBall));
                Console.SetCursorPosition(0, 3);
                Console.Write("top y konumu: " + Convert.ToInt32(positionYofBall));               
                

                //forReflectedAngle = random.NextDouble();
                //Console.SetCursorPosition(0,7);
                //Console.Write("yansıyan açı random: "+ forReflectedAngle);
                //forReflectedAngle = forReflectedAngle * 6 - 3;

                bool isCollision = false;

                for (int i = 0; i < y.Length; i++)
                {
                    if (Convert.ToInt32(positionYofBall) == y[i])
                    {
                        isCollision = true;
                        break;
                    }
                }

                bool isCollisionForEnemy = false;

                for (int i = 0; i < enemyY.Length; i++)
                {
                    if (Convert.ToInt32(positionYofBall) == enemyY[i])
                    {
                        isCollisionForEnemy = true;
                        break;
                    }
                }

                if ((positionXofBall <= 130 + r/2 && positionXofBall >= 130 - r/2) &&
                    isCollision)
                {
                    if (angle < Math.PI) angle += (Math.PI - 2 * atheta);
                    else angle -= (Math.PI - 2 * atheta);
                }
                if ((positionXofBall <= 30 + r / 2 && positionXofBall >= 30 - r/2) &&
                    isCollisionForEnemy)
                {
                    if (angle < Math.PI) angle -= (Math.PI - 2 * atheta);
                    else angle += (Math.PI - 2 * atheta);
                }
                if (Convert.ToInt32(positionYofBall) > 37)
                {
                    if (angle < Math.PI / 2) angle -= (2 * atheta);
                    else angle += (2 * atheta);

                }
                if (Convert.ToInt32(positionYofBall) < 7)
                {
                    if (angle > 3 * Math.PI / 2) angle += (2 * atheta);
                    else angle -= (2 * atheta);
                }
                angle = angle % (2 * Math.PI);
                if (angle < 0) angle += 2 * Math.PI;


                Console.SetCursorPosition(destroyBallX, destroyBallY);
                Console.Write(" ");

                if (destroyBallX == 81)
                {
                    Console.SetCursorPosition(destroyBallX, destroyBallY);
                    Console.WriteLine("●");
                }

                destroyBallX = Convert.ToInt32(positionXofBall);
                destroyBallY = Convert.ToInt32(positionYofBall);

                Console.SetCursorPosition(Convert.ToInt32(positionXofBall), Convert.ToInt32(positionYofBall));
                Console.Write("●");

                Thread.Sleep(125);
            }
        }
        public static void drawFrame()
        {
            for (int y = 5; y < 40; y++)
            {
                for (int x = 25; x < 136; x++)
                {
                    Console.SetCursorPosition(x, y);

                    if (x == 25 || x == 135)
                    {
                        Console.Write("|");
                    }
                    else if (y == 5 || y == 39)
                    {
                        Console.Write("-");
                    }
                    else if (x == 81 && y > 6 && y < 38)
                    {
                        Console.Write("●");
                    }
                }
            }
        }
        public static void drawPlayer(int dX, int[] dY)
        {
            for (int y = 0; y < dY.Length; y++)
            {
                Console.SetCursorPosition(dX, dY[y]);
                Console.Write("██");
            }
        }
        public static void deletePlayer(int dX, int dY)
        {
            Console.SetCursorPosition(dX, dY);
            Console.Write("  ");
        }

        public static void drawEnemy(int dX, int[] dY)
        {
            for (int y = 0; y < dY.Length; y++)
            {
                Console.SetCursorPosition(dX, dY[y]);
                Console.Write("██");
            }
        }
        public static double throwBall(out double yPoint)
        {
            Random random = new Random();
            yPoint = random.Next(7, 38);           

            double teta = Math.Atan2(22-yPoint, 53); //radyan                

            return teta;
        }
    }
}
