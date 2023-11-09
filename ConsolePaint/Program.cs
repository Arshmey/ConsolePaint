using System;
using System.Collections.Generic;

namespace ConsolePaint
{
    internal class Program
    {
        static int x = 0;
        static int y = 1;
        static List<pixInfo> pixInfo = new List<pixInfo>();
        static saveLoad saveLoad = new saveLoad();
        static int choose = 0;
        static List<ConsoleColor> colors = new List<ConsoleColor>() { ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue,
            ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Gray, ConsoleColor.White, ConsoleColor.DarkRed,
            ConsoleColor.DarkGreen, ConsoleColor.DarkBlue, ConsoleColor.DarkYellow, ConsoleColor.DarkCyan, ConsoleColor.DarkMagenta,
            ConsoleColor.DarkGray};
        static bool autoPaint = false;

        static void Main(string[] args)
        {
            Console.Title = "Console Paint";
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("X: " + x + ", Y: " + y + ", Color: " + colors[choose].ToString() + ", Pixels: " + pixInfo.Count + "     ");
                Console.BackgroundColor = colors[choose];
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("         ");

                Repaint();

                Console.SetCursorPosition(x, y);

                Move();
            }
        }

        private static void Move()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.W)
            {
                y--;
                if (y != 0) { Console.SetCursorPosition(x, y); }
                else { y++; Console.SetCursorPosition(x, y); }
            } 
            if (key == ConsoleKey.S)
            {
                y++;
                if (y != 30) { Console.SetCursorPosition(x, y); }
                else { y--; Console.SetCursorPosition(x, y); }
            }
            if (key == ConsoleKey.A)
            {
                x--;
                if (x != -1) { Console.SetCursorPosition(x, y); }
                else { x++; Console.SetCursorPosition(x, y); }
            } 
            if (key == ConsoleKey.D)
            {
                x++;
                if (x != 120) { Console.SetCursorPosition(x, y); }
                else { x--; Console.SetCursorPosition(x, y); }
            }
            if (key == ConsoleKey.Spacebar | autoPaint == true)
            {
                CleanCoincidences();
                pixInfo.Add(new pixInfo(x, y, choose));
            }
            if (key == ConsoleKey.E)
            {
                choose++;
                if (choose == colors.Count)
                {
                    choose = 0;
                }
            }
            if (key == ConsoleKey.Q)
            {
                if (choose == 0)
                {
                    choose = colors.Count;
                }
                choose--;
            }
            if (key == ConsoleKey.P)
            {
                for (int i = 0; i < pixInfo.Count; i++)
                {
                    if (pixInfo[i].x_pixel == x && pixInfo[i].y_pixel == y)
                    {
                        choose = pixInfo[i].choose;
                    }
                }
            }
            if (key == ConsoleKey.R)
            {
                if(autoPaint == false) { autoPaint = true; }
                else { autoPaint = false; }
            }
            if (key == ConsoleKey.Delete)
            {
                pixInfo.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
            }
            if (key == ConsoleKey.M)
            {
                saveLoad.Save(pixInfo);
            }
            if (key == ConsoleKey.L)
            {
                pixInfo.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                saveLoad.Load();
                pixInfo = saveLoad.pixInfoLoad;
            }
        }

        private static void Repaint()
        {
            foreach (var info in pixInfo)
            {
                Console.SetCursorPosition(info.x_pixel, info.y_pixel);
                Console.BackgroundColor = colors[info.choose];
                Console.Write(" ");
            }
        }

        private static void CleanCoincidences()
        {
            foreach (var info in pixInfo)
            {
                if (x == info.x_pixel && y == info.y_pixel)
                {
                    pixInfo.Remove(info);
                    info.choose = choose;
                    break;
                } 
            }
        }

    }
}
