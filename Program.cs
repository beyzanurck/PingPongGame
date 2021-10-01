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

            while (true)
            {
                Console.SetCursorPosition(x, y[0]);
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        direction += 1;
                        break;
                    case ConsoleKey.DownArrow:
                        direction -= 1;
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
            

            Console.ReadLine();
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
                    else if (x == 79 && y > 6 && y < 38)
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
                Console.Write("█");     
            }
        }

        public static void deletePlayer(int dX, int dY)
        {
            Console.SetCursorPosition(dX, dY);
            Console.Write(" ");
        }
    }
}
