using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellinlämning___Kassasystem_2._0
{
    public enum priceType
    {
        kg = 1,
        st = 2
    }
    internal class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public priceType PriceType { get; set; }


        public static List<Product> ProductList = new List<Product>();

        public Product(int iD, string productName, decimal price, priceType type)
        {
            ProductId = iD;
            ProductName = productName;
            ProductPrice = price;
            PriceType = type;

        }

        /// <summary>
        /// Skapar en lista av produkterna
        /// </summary>
        public static void CreateProductList()
        {
            var product = new List<Product>();

            product.Add(new Product(1001, "Banner", 19.99m, priceType.kg));
            product.Add(new Product(1002, "Äpplen", 14.99m, priceType.kg));
            product.Add(new Product(2001, "Mjölk", 21.99m, priceType.st));
            product.Add(new Product(2002, "Yogurt", 18.99m, priceType.st));
            product.Add(new Product(3001, "Mjöl", 19.99m, priceType.st));

            foreach (var item in product)
            {
                ProductList.Add(item);
            }


        }
        /// <summary>
        /// Method för att kolla efter inmatad ID
        /// </summary>
        /// <param name="idNum"></param>
        /// <param name="unit"></param>
        public static void CheckForProduct(int idNum, decimal unit)
        {
            int index = 1;
            foreach (var product in ProductList)
            {
                if (idNum == product.ProductId)
                {
                    if (product.PriceType == priceType.kg)
                    {
                        var price = product.ProductPrice * unit;
                        Console.WriteLine($"{product.ProductName} - {price} kr - ({unit} kg)");

                        Receipt.ProductInReceipt(product.ProductName, price);
                        break;
                    }
                    else if (product.PriceType == priceType.st)
                    {
                        unit = Math.Floor(unit);

                        if (unit <= 0)
                        {
                            unit = 1;
                        }

                        var price = product.ProductPrice * unit;
                        Console.WriteLine($"{product.ProductName} - {price} kr - ({unit} st)");

                        Receipt.ProductInReceipt(product.ProductName, price);
                        break;

                    }

                }
                else if (index == ProductList.Count)
                {
                    Console.WriteLine("Kunde ej hitta ID koden");
                }

                index++;
            }
        }
    }
}
