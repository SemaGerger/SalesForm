using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknosaSatisUygulamasi
{
    internal class Product:InheritanceProp
    {
        public int Stock { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
