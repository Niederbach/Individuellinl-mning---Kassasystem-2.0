using Individuellinlämning___Kassasystem_2._0.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;


namespace Individuellinlämning___Kassasystem_2._0.DisplayTools
{
    static class Display
    {
        public static void ShowMenu(List<Menu> options)
        {
            int selectedIndex = 0;
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Kassasystem - Meny");
                Console.ResetColor();
                Console.WriteLine("(Använd piltagenten för att flytta upp och ner)");
                Console.WriteLine("-----------------------------------------------");

                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(options[i].MenuName);

                    Console.ResetColor();
                }

                if (selectedIndex == options.Count)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exit");
                Console.ResetColor();

                var keyInput = Console.ReadKey(true);

                if (keyInput.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Count;
                    }

                }
                else if (keyInput.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex > options.Count)
                    {
                        selectedIndex = 0;
                    }
                }
                else if (keyInput.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == options.Count)
                    {
                        running = false;
                        Console.ReadKey();
                    }
                    else if (selectedIndex == 0)
                    {
                        Console.Clear();

                        var register = new Register("Kassa");
                       
                        register.ShowRegister();

                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();

                        var administrator = new Administrator("Admin");

                        administrator.ShowAdministaror();
                    }
                }
            }
        }






    }
}