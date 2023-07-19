using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknosaSatisUygulamasi
{
    internal class DbContext
    {
        public static List<Product> productList = new List<Product>();
        public static List<Customer> customerList = new List<Customer>();
        public static List<Order> orderList=new List<Order>();
    }
}
