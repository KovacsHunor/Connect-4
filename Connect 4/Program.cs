using System;
using System.Threading;
namespace Connect_4
{
    class Program
    {
        static int w = Console.WindowWidth;
        static int[] column = new int[8];
        static int[,] matrix = new int[7, 8];
        static int number = 4;
        static int y = 9;
        static int m = 31;
        static bool end = false;
        static bool arrows = false;
        static ConsoleKeyInfo input;
        static void Menu() 
        {
            bool end = false;
            bool m = false;
            Console.SetCursorPosition(w / 2 - 15, 10);
            Console.WriteLine("Hogy szeretnél korongokat dobni?");
            Console.SetCursorPosition(w / 2 - 5, 12);
            Console.WriteLine("» Nyilakkal");
            Console.SetCursorPosition(w / 2 - 5, 13);
            Console.WriteLine("Számokkal");
            while (end == false)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.DownArrow && m == false)
                {
                    Console.SetCursorPosition(w / 2 - 5, 12);
                    Console.Write("           ");
                    Console.SetCursorPosition(w / 2 - 5, 12);
                    Console.Write("Nyilakkal");
                    Console.SetCursorPosition(w / 2 - 5, 13);
                    Console.Write("» Számokkal");
                    m = true;
                }
                else if (input.Key == ConsoleKey.UpArrow && m == true)
                {
                    Console.SetCursorPosition(w / 2 - 5, 12);
                    Console.Write("» Nyilakkal");
                    Console.SetCursorPosition(w / 2 - 5, 13);
                    Console.Write("           ");
                    Console.SetCursorPosition(w / 2 - 5, 13);
                    Console.Write("Számokkal");
                    m = false;
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    if (m == false)
                    {
                        arrows = true;
                        end = true;
                    }
                    else
                    {
                        end = true;
                    }
                }
            }
        }
        static int x = 1;
        static void Input()
        {
            void Indisk()
            {
                if (x % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (x % 2 == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.SetCursorPosition(25 + 10 * (number - 2) - 2, 2);
                Console.Write("                                       ");
                Console.SetCursorPosition(24 + 10 * (number - 2) - 2, 3);
                Console.Write("                                       ");
                Console.SetCursorPosition(25 + 10 * (number - 2) - 2, 4);
                Console.Write("                                       ");
                Console.SetCursorPosition(25 + 10 * (number - 1), 2);
                Console.Write("██████");
                Console.SetCursorPosition(24 + 10 * (number - 1), 3);
                Console.Write("████████");
                Console.SetCursorPosition(25 + 10 * (number - 1), 4);
                Console.Write("██████");
            }
            bool n = false;
            if (arrows)
            {
                Indisk();
                while (!n)
                {
                    ConsoleKeyInfo input = Console.ReadKey(true);
                    if (input.Key == ConsoleKey.RightArrow && number < 7)
                    {
                        number += 1;
                        Indisk();
                    }
                    else if (input.Key == ConsoleKey.LeftArrow && number > 1)
                    {
                        number -= 1;
                        Indisk();
                    }
                    else if (input.Key == ConsoleKey.Enter)
                    {
                        n = true;
                    }
                }
            }
            if (x % 2 == 1)
            {
                Console.SetCursorPosition(y, m);
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (!arrows)
                {
                    Console.SetCursorPosition(y, m);
                    Console.Write("A:");
                }
            }
            else if (x % 2 == 0)
            {
                Console.SetCursorPosition(y, m);
                Console.ForegroundColor = ConsoleColor.Red;
                
                if (!arrows)
                {
                    Console.SetCursorPosition(y, m);
                    Console.Write("B:");
                }
            }
            if(!arrows)
            {
                do
                {
                    if (q == true)
                    {
                        Console.SetCursorPosition(y, m);
                        Console.Write("   ");
                        if (x % 2 == 1)
                        {
                            Console.SetCursorPosition(y, m);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(y, m);
                            Console.Write("A:");
                        }
                        else if (x % 2 == 0)
                        {
                            Console.SetCursorPosition(y, m);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(y, m);
                            Console.Write("B:");
                        }
                    }
                    input = Console.ReadKey();
                    number = Convert.ToInt32(input.KeyChar) - 48;
                    q = true;
                } while (number < 1 || number > 7 || column[number] > 5);
            }
        }
        static bool q = false;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WindowHeight = 36;
            while (end == false)
            {
                Menu();
                draw();
                Console.SetCursorPosition(y, m);
                while (end == false)
                {
                    contraction(-1, 1, -2, 2, -3, 3);
                    contraction(1, -1, -2, 2, -1, 1);
                    contraction(1, -1, 2, -2, 3, -3);
                    contraction(-1, 1, 2, -2, 1, -1);
                    contraction(1, 1, 2, 2, 3, 3);
                    contraction(1, 1, 2, 2, -1, -1);
                    contraction(-1, -1, -2, -2, -3, -3);
                    contraction(-1, -1, -2, -2, 1, 1);
                    contraction(-1, 0, -2, 0, -3, 0);
                    contraction(0, 1, 0, 2, 0, 3);
                    contraction(0, 1, 0, 2, 0, -1);
                    contraction(0, -1, 0, -2, 0, -3);
                    contraction(0, -1, 0, -2, 0, 1);
                    int c = 0;
                    for (int p = 1; p < 7; p++)
                    {
                        for (int i = 1; i < 8; i++)
                        {
                            if (matrix[p, i] == 0)
                            {
                                c++;
                            }
                        }
                    }
                    if (c == 0 && end == false)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\n Vége a játéknak, ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("DÖNTETLEN");
                        Console.ForegroundColor = ConsoleColor.White;
                        end = true;
                    }
                    if (end == false)
                    {
                        do
                        {
                            Input();
                            q = true;
                        } while (number < 1 || number > 7 || column[number] > 5) ;
                        q = false;
                        disc();
                        x++;
                    }
                    if (end == true)
                    {
                        Console.Write("\n Ha szeretnél játszani még egyet, írd be, hogy: again\n Ha ki szeretnél lépni, írd be, hogy: exit");
                        Console.WriteLine();
                        string v = Console.ReadLine();
                        while (v != "again" && v != "exit")
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            Console.Write("\r" + new string(' ', w - 1) + "\r");
                            v = Console.ReadLine();
                        }
                        if (v == "again")
                        {
                            end = false;
                            x = 1;
                            for (int i = 0; i < column.Length; i++)
                            {
                                column[i] = 0;
                            }
                            for (int p = 0; p < 7; p++)
                            {
                                for (int i = 0; i < 8; i++)
                                {
                                    matrix[p, i] = 0;
                                }
                            }
                            number = 4;
                            y = 9;
                            m = 31;
                            draw();
                            Console.SetCursorPosition(y, m);
                        }
                    }
                }
                end = true;
            }
        }
        static void contraction(int a1, int b1, int a2, int b2, int a3, int b3)
            {
            try
            {
                if (matrix[column[number], number] == matrix[column[number] + a1, number + b1] &&
               matrix[column[number], number] == matrix[column[number] + a2, number + b2] &&
               matrix[column[number], number] == matrix[column[number] + a3, number + b3] &&
               matrix[column[number], number] != 0 && end == false)
                {
                    inif();
                }
            }
            catch (Exception) { }
        }
        static void draw() 
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int p = 0; p < 6; p++)
            {
                Console.WriteLine();
                Console.Write("                       ");
                for (int i = 0; i < 7; i++)
                {
                    Console.Write("██████████");
                }
                Console.WriteLine();
                Console.Write("                       ");
                for (int i = 0; i < 7; i++)
                {
                    Console.Write("█        █");
                }
                Console.WriteLine();
                Console.Write("                       ");
                for (int i = 0; i < 7; i++)
                {
                    Console.Write("█        █");
                }
                Console.WriteLine();
                Console.Write("                       ");
                for (int i = 0; i < 7; i++)
                {
                    Console.Write("█        █");
                }
            }
            Console.WriteLine();
            Console.Write("                       ");
            for (int i = 0; i < 7; i++)
            {
                Console.Write("█████");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(i + 1);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("████");
            }
        }
        static void inif()
        {
            if (y > w - 10)
            {
                m++;
                y = 4;
            }
            y += 5;
            Console.SetCursorPosition(y, m);
            end = true;
            bool color = false;
            if (Console.ForegroundColor == ConsoleColor.Yellow)
            {
                color = true;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n Vége a játéknak, ");
            if (color)
            {               
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("SÁRGA");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("PIROS");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" nyert");
        }
        static double ido;
        static void Grav(double tav)
        {
            if (tav != 27 - 4 * column[number])
            {
                ido = Math.Sqrt(tav / 5) - Math.Sqrt((tav - 1) / 5);
                Thread.Sleep((int)(ido * 150));
                if (((int)tav + 2) % 4 != 0 || tav <= 3)
                {
                    Console.SetCursorPosition(15 + 10 * number, (int)tav);
                    Console.Write("      ");
                }
                if (((int)tav + 3) % 4 != 0)
                {
                    Console.SetCursorPosition(14 + 10 * number, (int)tav + 1);
                    Console.Write("        ");
                }
                if (((int)tav + 4) % 4 != 0)
                {
                    Console.SetCursorPosition(15 + 10 * number, (int)tav + 2);
                    Console.Write("      ");
                }
                if (((int)tav + 3) % 4 != 0)
                {
                    Console.SetCursorPosition(15 + 10 * number, (int)tav + 1);
                    Console.Write("██████");
                }
                if (((int)tav + 4) % 4 != 0)
                {
                    Console.SetCursorPosition(14 + 10 * number, (int)tav + 2);
                    Console.Write("████████");
                }
                if (((int)tav + 5) % 4 != 0)
                {
                    Console.SetCursorPosition(15 + 10 * number, (int)tav + 3);
                    Console.Write("██████");
                }
                Grav(tav + 1);
            }
            if (x % 2 == 1)
            {
                Console.SetCursorPosition(y, m);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("A:" + number);
            }
            else if (x % 2 == 0)
            {
                Console.SetCursorPosition(y, m);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("B:" + number);
            }
        }
        static void disc()
        {
            if (column[number] < 6)
            {
                Grav(1);
                column[number]++;
                if (Console.ForegroundColor == ConsoleColor.Yellow)
                {
                    matrix[column[number], number] = 1;
                }
                else if (Console.ForegroundColor == ConsoleColor.Red)
                {
                    matrix[column[number], number] = 2;
                }
                if (y > w - 10)
                {
                    m++;
                    y = 4;
                }
                y += 5;
                Console.SetCursorPosition(y, m);
            }
        }
    }
}

