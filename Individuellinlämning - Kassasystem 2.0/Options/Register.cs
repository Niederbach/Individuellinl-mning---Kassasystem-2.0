using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Individuellinlämning___Kassasystem_2._0.Options
{
    public class Register : Menu
    {
        public Register(string menuName) : base(menuName)
        {

        }

        public void ShowRegister()
        {
            Product.CreateProductList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Kassasystem - Kassa");
            Console.ResetColor();
            Console.WriteLine("(Skriv PAY för att betala)");
            Console.WriteLine("-------------------");

            foreach (Product product in Product.ProductList)
            {
                Console.WriteLine($"#{product.ProductId} - {product.ProductName} - {product.ProductPrice}" +
                    $" kr/{product.PriceType}");
            }
            Console.WriteLine("-------------------");

            while (true)
            {
                string[] inputArray;
                try
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Skriv in ID och KG/ST");
                    Console.Write(">>> ");
                    Console.ResetColor();
                    inputArray = Console.ReadLine().Split(' ');

                    inputArray[0] = inputArray[0].ToLower();

                    if (inputArray[0] == "pay")
                    {
                        Console.Clear();
                        Receipt.PrintReceipt();

                        Console.ReadKey();

                        break;
                    }

                    Console.SetCursorPosition(0, Console.CursorTop - 2);

                    int idNum = int.Parse(inputArray[0]);
                    decimal unit = decimal.Parse(inputArray[1]);

                    Product.CheckForProduct(idNum, unit);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning! försök ingen");
                    Console.ResetColor();
                }
                catch (IndexOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Glömde du lägga till ID eller KG/ST?");
                    Console.ResetColor();
                }
            }

            Product.ProductList.Clear();
        }



    }
}
