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
            int y = 20;
            int y0 = 0;
            int direction = 0;
            drawPlayer(y,x);

            while (true)
            {
                Console.SetCursorPosition(x, y);
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
                    y0 = y + 7;
                    direction = 0;
                    y = y - 1;
                    drawPlayer(y, x);
                    deletePlayer(y0, x);
                }

                if (direction < 0)
                {
                    y0 = y;
                    direction = 0;
                    y = y + 1;
                    drawPlayer(y, x);
                    deletePlayer(y0, x);
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
                }
            }
        }

        public static void drawPlayer(int dY, int dX)
        {
            for (int y = dY; y < dY + 8; y++)
            {
                for (int x = dX; x < dX + 2; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("█");
                }
            }
        }

        public static void deletePlayer(int dY, int dX)
        {
            for (int y = dY; y < dY + 1; y++)
            {
                for (int x = dX; x < dX + 2; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
            }
        }
    }
}
