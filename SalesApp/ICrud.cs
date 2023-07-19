using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknosaSatisUygulamasi
{
    internal interface ICrud<T>
    {
        bool Add(T entity);
        bool Delete(int id);
        List<T> List();
        T Detail(int id);
    }
}
