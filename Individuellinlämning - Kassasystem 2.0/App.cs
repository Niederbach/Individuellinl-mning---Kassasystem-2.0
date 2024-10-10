using Individuellinlämning___Kassasystem_2._0.Options;
using Individuellinlämning___Kassasystem_2._0.DisplayTools;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellinlämning___Kassasystem_2._0
{
    internal class App
    { 
        public void Run()
        {
            var options = new List<Menu>()
            {
                new Register("Kassa"),
                new Administrator("Administatör")

            };

            Display.ShowMenu(options);


        }
    }
}
