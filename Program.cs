using System;
using System.Text;

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

            double xOfAngle;
            double yOfAngle;

            double angle = throwBall();
            int ballX = 0;
            int ballY = 0;

            int destroyBallX = 0;
            int destroyBallY = 0;

            int a = 81, b = 7;
            //throwBall(out xOfAngle,out yOfAngle);

            //for (int r = 0; r < 50; r=r+4)
            //{
            //    ballX = Convert.ToInt32(xOfAngle * r);
            //    ballY = Convert.ToInt32(yOfAngle * r);

            //    Console.SetCursorPosition(destroyBallX + 81, destroyBallY + 7);
            //    Console.Write(" ");

            //    destroyBallX = ballX;
            //    destroyBallY = ballY;

            //    Console.SetCursorPosition(ballX + 81, ballY + 7);
            //    Console.Write("X");


            //}

            int dirOfBall = 1;

            int r = 0;
            while (true)
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


                if (dirOfBall == 1)
                {
                    r += 4;

                    ballX = Convert.ToInt32(Math.Cos(angle) * r);
                    ballY = Convert.ToInt32(Math.Sin(angle) * r);
                    
                }


                if (ballX > 130 - 81 && dirOfBall != 4)
                {
                    dirOfBall = 2;
                    r = 0;
                    
                }
                if (dirOfBall == 2)
                {
                    r += 4;
                    ballX = Convert.ToInt32(Math.Cos(Math.PI - angle) * r);
                    ballY = Convert.ToInt32(Math.Sin(Math.PI - angle) * r);
                    
                }


                if (ballY > 38 - 22)
                {
                    dirOfBall = 3;
                    r = 0;
                }
                if (dirOfBall == 3)
                {
                    r += 4;

                    ballX = Convert.ToInt32(Math.Cos(Math.PI + angle) * r);
                    ballY = Convert.ToInt32(Math.Sin(Math.PI + angle) * r);
                    
                }

                if (ballX < -46 && dirOfBall !=2) // 
                {
                    dirOfBall = 4;
                    r = 0;
                }
                if (dirOfBall == 4)
                {
                    r += 4;

                    ballX = Convert.ToInt32(Math.Cos(2*Math.PI - angle) * r);
                    ballY = Convert.ToInt32(Math.Sin(2*Math.PI - angle) * r);
                    
                }


                Console.SetCursorPosition(destroyBallX + a, destroyBallY + b);
                Console.Write(" ");

                destroyBallX = ballX;
                destroyBallY = ballY;


                if (dirOfBall== 1)
                {
                    a = 81;
                    b = 7;
                }
              
               

                if (dirOfBall == 2)
                {
                    a = 130;
                    b = 22;

                }

                if (dirOfBall == 3)
                {
                    a = 72;
                    b = 38;

                }

                if (dirOfBall == 4)
                {
                    a = 25;
                    b = 22;

                }
                if (ballY < -15)
                {
                    dirOfBall = 1;
                    r = 0;
                }
                Console.SetCursorPosition(ballX + a, ballY + b);
                Console.Write("X");



              


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

        //public static void throwBall(out double x, out double y)
        //{
        //    Random random = new Random();
        //    int yPoint = random.Next(7, 38);
        //    yPoint = 7;
        //    double teta = Math.Atan2(15,53); //radyan            

        //    x = (Math.Cos(teta));
        //    y = (Math.Sin(teta));

        //}

        public static double throwBall()
        {
            Random random = new Random();
            int yPoint = random.Next(7, 38);
            yPoint = 7;
            double teta = Math.Atan2(15, 53); //radyan            

            return teta;


        }
    }
}
