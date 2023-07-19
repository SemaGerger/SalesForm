using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknosaSatisUygulamasi
{
    internal class ProductProccess : ICrud<Product>
    {
        public bool Add(Product entity)
        {
            bool result = false;
            if (entity != null)
            {
                DbContext.productList.Add(entity);
                result = true;//ekleme başarılı olursa true 
            }
            return result;//ekleme yapamazsa resault değeri false dönecek
        }

        public bool Delete(int id)
        {
            bool resault = false;
            foreach (var product in DbContext.productList.ToList())
            {
                if (id == product.Id)
                {
                    DbContext.productList.Remove(product);
                    resault = true;
                    break;
                }
            }

            return resault;
        }

        public Product Detail(int id)
        {
            Product result = null;
            foreach (var product in DbContext.productList.ToList())
            {
                if (id == product.Id)
                {
                    result=product;
                    break;
                }
            }
            return result;
        }

        public List<Product> List()
        {
            return DbContext.productList.ToList();
        }
    }
}
