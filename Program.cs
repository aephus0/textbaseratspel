using System;
using System.IO;
namespace Speltext
{
    
    class Program
    {
        static bool flag = false;
        static bool gamestate = false;
        static string path = @".\";
        static int posx = 2;
        static int posy = 2;

        static int prevx = 2;
        static int prevy = 2;
        static Charvals mainc = new Charvals();
        static string[,] array1 = new string[,]{
            {"O","O","O","O","O"},
            {"O","O","O","O","O"},
            {"O","O","O","O","O"},
            {"O","O","O","O","O"},
            {"O","O","O","O","O"}
        };
        

        static void checkgamestate()
        {
            try
            {
                if (File.Exists(@".\gamestate"))
                {
                    gamestate = true;
                    Console.WriteLine("file exists...");
                }
                else if (File.Exists(@".\gamestate.txt") == false)
                {
                    gamestate = false;
                    File.Create(@".\gamestate.txt");
                    Console.WriteLine("file does not exist...");
                }
            }
            catch (FileLoadException)
            {
                Console.WriteLine("File cannot be loaded... Exiting program.");
            }
            
        }

        static void startingchecks()
        {
            checkgamestate();

        }

        static void dumpsavedata()
        {

        }

        static void charactercreator()
        {
            mainc.name = Console.ReadLine();
        }

        // Main menu function includes starting a new game and exiting the program.
        static void menu()
        {
            Console.WriteLine();
            Console.WriteLine("*MENU*");
            Console.WriteLine();
            Console.WriteLine("Press 'F1' to start a new game.");
            Console.WriteLine("Press 'F2' to load a saved game.");
            Console.WriteLine("Press 'F3' to quit.");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.F1:
                    flag = true;
                    break;
                case ConsoleKey.F2:
                    Console.WriteLine("This is the second command.");
                    break;
                case ConsoleKey.F3:
                    Console.Clear();
                    Console.WriteLine("Are you sure you wish to quit?");
                    Console.WriteLine("'Y'es, 'N'o");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Y:
                            flag = false;
                            break;
                        case ConsoleKey.N:
                            flag = true;
                            Console.Clear();
                            menu();
                            break;
                        default:
                            menu();
                            break;
                    }

                    if (flag == false)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        menu();
                    }

                    break;

                default:
                    menu();
                    break;
            }
        }
        static void drawmap()
        {
            array1[prevx, prevy] = "O";
            array1[posx, posy] = "X";
            Console.Clear();
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    Console.Write(array1[i, j] + " ");
                }
            }
        }
        // Main game loop.
        static void Main()
        {
            menu();
            
            while (flag)
            {
                drawmap();
                

                
                checkgamestate();
                Console.ReadLine();
            }

        }
        class Charvals
        {
            public string name = "";
            public int level = 1;
            public int health = 100;
            public int rpower = 10;
        }
        
    }
}
