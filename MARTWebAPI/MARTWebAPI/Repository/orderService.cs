using MARTWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARTWebAPI.Repository
{
    public class orderService:IOrder
    {
        private readonly MARTContext context;

        public orderService( MARTContext context )
        {
            this.context = context;
        }

        //to get details of all orders
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            return await context.Orders.ToListAsync();
        }

        //to get details of particular order by orderid
        public async Task<Orders> GetOrder(int Orderid)
        {
            return await context.Orders.FirstOrDefaultAsync(o => o.Id == Orderid);
        }

        //to add order
        public async Task<Orders> AddOrder(Orders orders)
        {
            var result = await context.Orders.AddAsync(orders);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        //to update an existing order
        public async Task<Orders> UpdateOrder(Orders orders)
        {
            var result = await context.Orders.FirstOrDefaultAsync(o => o.Id == orders.Id);
            if (result != null)
            {
                result.Id = orders.Id;
                result.UserId = orders.UserId;
                result.Emailadress = orders.Emailadress;
                result.Mobilenumber = orders.Mobilenumber;
                result.TotalPrice = orders.TotalPrice;
                result.Address= orders.Address;
                await context.SaveChangesAsync();
            }
            return result;
        }

        //to delete an existing order
        public async Task<Orders> DeleteOrder(int orderid)
        {
            var result = await context.Orders.FirstOrDefaultAsync(o => o.Id == orderid);
            if (result != null)
            {
                context.Orders.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}
