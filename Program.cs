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
            int[] y = new int[]{ 20, 21, 22, 23, 24, 25, 26, 27 };            
            int y0 = 0;
            int direction = 0;
            drawPlayer(x,y);

            int ballX;
            int ballY;

            throwBall(out ballX,out ballY);
            Console.SetCursorPosition(ballX+81, ballY+7);
            Console.Write("X");
            
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

        public static void throwBall(out int x, out int y)
        {
            Random random = new Random();
            int yPoint = random.Next(7, 38);
            yPoint = 7;
            double teta = Math.Atan2(15,53); //radyan            

            x = Convert.ToInt32(Math.Cos(teta));
            y = Convert.ToInt32(Math.Sin(teta));
        }

    }
}
