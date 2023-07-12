using MARTWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARTWebAPI.Repository
{
  public interface IOrder
    {
        Task<IEnumerable<Orders>> GetAllOrders();
        Task<Orders> GetOrder(int Orderid);
        Task<Orders> AddOrder(Orders orders);
        Task<Orders> UpdateOrder(Orders orders);
        Task<Orders> DeleteOrder(int orderid);

    }
}
