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

            int x = 130;
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

                Console.SetCursorPosition(0, 3);
                Console.Write("angle: " + angle * 180 / (Math.PI));
                Console.SetCursorPosition(0, 5);
                Console.Write("top x konumu:      ");
                Console.SetCursorPosition(0, 5);
                Console.Write("top x konumu: " + Convert.ToInt32(positionXofBall));
                Console.SetCursorPosition(0, 6);
                Console.Write("top x noktası: " + Convert.ToInt32(pointXofBall));

                Console.SetCursorPosition(0, 7);
                Console.Write("top y konumu: " + Convert.ToInt32(positionYofBall));
                Console.SetCursorPosition(0, 8);
                Console.Write("top y noktası: " + Convert.ToInt32(pointYofBall));

                //forReflectedAngle = random.NextDouble();
                //Console.SetCursorPosition(0,7);
                //Console.Write("yansıyan açı random: "+ forReflectedAngle);
                //forReflectedAngle = forReflectedAngle * 6 - 3;

                if (Convert.ToInt32(positionXofBall) > 130)
                {
                    //angle = Math.PI - theta;  
                    if (angle < Math.PI) angle += (Math.PI - 2 * atheta);
                    else angle -= (Math.PI - 2 * atheta);
                }
                if (Convert.ToInt32(positionXofBall) < 24)
                {
                    //angle = 2 * Math.PI - theta;
                    if (angle < Math.PI) angle -= (Math.PI - 2 * atheta);
                    else angle += (Math.PI - 2 * atheta);

                }
                if (Convert.ToInt32(positionYofBall) > 37)
                {
                    //angle = Math.PI + theta; 
                    if (angle < Math.PI / 2) angle -= (2 * atheta);
                    else angle += (2 * atheta);

                }
                if (Convert.ToInt32(positionYofBall) < 7)
                {
                    //angle = theta;       
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
                for (int x = 25; x < 135; x++)
                {
                    Console.SetCursorPosition(x, y);

                    if (x == 25 || x == 134)
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
        public static double throwBall(out double yPoint)
        {
            Random random = new Random();
            yPoint = random.Next(7, 38);
            yPoint = 21;
          
            double teta = Math.Atan2(22-yPoint, 53); //radyan                

            return teta;
        }
    }
}
