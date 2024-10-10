using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Individuellinlämning___Kassasystem_2._0.Options
{
    public class Administrator : Menu
    {
        public Administrator(string menuName) : base (menuName) 
        {
            
        }

        public void ShowAdministaror()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("OBS!! ej färdig");
            Console.ResetColor();
            Console.WriteLine("Använd dig av valfri tagent för att gå tillbaka till menyn");

            Console.ReadKey();
        }
        
    }
}
