using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknosaSatisUygulamasi
{
    internal class OrderProccess : ICrud<Order>
    {
        public bool Add(Order entity)
        {
            bool result = false;

            foreach (var customer in DbContext.customerList.ToList())
            {
                if (customer.Id == entity.CustomerId)
                {
                    foreach (var product in DbContext.productList.ToList())
                    {
                        if (product.Id == entity.ProductId && product.Stock>=entity.Quantity && customer.Balance>=(product.Price*entity.Quantity))
                        {
                            customer.Balance -= entity.Quantity * product.Price;
                            product.Stock-=entity.Quantity;

                            entity.TotalPrice = entity.Quantity * product.Price;

                            DbContext.orderList.Add(entity);
                            result = true;
                            break;
                        }
                    }

                    break;
                }
            }
            return result;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order Detail(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> List()
        {
            return DbContext.orderList.ToList();
        }
    }
}
