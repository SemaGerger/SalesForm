using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknosaSatisUygulamasi
{
    internal class CustomerProccess : ICrud<Customer>
    {
        public bool Add(Customer entity)
        {
            bool result = false;
            if (entity != null)
            {
                DbContext.customerList.Add(entity);
                result = true;//ekleme başarılı olursa true 
            }
            return result;//ekleme yapamazsa resault değeri false dönecek
        }

        public bool Delete(int id)
        {
            bool resault = false;
            foreach (var customer in DbContext.customerList.ToList())
            {
                if (id == customer.Id)
                {
                    DbContext.customerList.Remove(customer);
                    resault = true;
                    break;
                }
            }

            return resault;
        }

        public Customer Detail(int id)
        {
            Customer result = null;
            foreach (var customer in DbContext.customerList.ToList())
            {
                if (id == customer.Id)
                {
                    result = customer;
                    break;
                }
            }
            return result;
        }

        public List<Customer> List()
        {
            return DbContext.customerList.ToList();
        }
    }
}
