using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellinlämning___Kassasystem_2._0.Options
{
    public abstract class Menu
    {
        public string MenuName { get; set; }
        public Menu(string menuName)
        {
            MenuName = menuName;

        }
    }
}
