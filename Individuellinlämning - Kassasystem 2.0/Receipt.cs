using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Individuellinlämning___Kassasystem_2._0
{
    internal class Receipt
    {
        private static int _currentReceipt = 1000;
        public int ReceiptId { get; private set; }

        public string ReceiptName { get; set; }

        public decimal ReceiptPrice { get; set; }

        public static string ReceiptDay = DateTime.Now.ToShortDateString();

        public static List<Receipt> ReceiptList = new List<Receipt>();

        public Receipt(decimal price, string name)
        {
            ReceiptName = name;
            ReceiptPrice = price;
            ReceiptId += ++_currentReceipt;


        }
        public static void ProductInReceipt(string ProductName, decimal price)
        {

            var receipt = new Receipt(price, ProductName);

            ReceiptList.Add(receipt);
        }
        public static void PrintReceipt()
        {
            
            var filePath = $"../../../File/#{ReceiptList.First().ReceiptId}-reacipt-{ReceiptDay}.txt";

            using (StreamWriter writeReceipt = new StreamWriter(filePath, append: true))
            {
                writeReceipt.WriteLine($"KVITTO ID: {ReceiptList.First().ReceiptId}");
                writeReceipt.WriteLine(ReceiptDay);
                writeReceipt.WriteLine("-----------");

                foreach (var receipt in ReceiptList)
                {
                    writeReceipt.WriteLine($"{receipt.ReceiptName} - {receipt.ReceiptPrice} kr");
                }

                decimal sum = 0;

                foreach (var receipt in ReceiptList)
                {

                    sum += receipt.ReceiptPrice;

                }

                writeReceipt.WriteLine("-----------");
                writeReceipt.WriteLine($"Totala priset: {sum} kr");
            }

            using (StreamReader readReceipt = new StreamReader(filePath))
            {
                while (readReceipt.Peek() >= 0)
                {
                    Console.WriteLine(readReceipt.ReadLine());

                }
            }

            ReceiptList.Clear();
        }
    }
}
