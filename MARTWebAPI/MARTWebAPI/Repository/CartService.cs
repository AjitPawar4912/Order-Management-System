using MARTWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARTWebAPI.Repository
{
    public class CartService:ICart
    {
        private readonly MARTContext context;

        public CartService(MARTContext context)
        {
            this.context = context;
        }

        //to get details of all cart
        public async Task<IEnumerable<Carts>> GetAllCart()
        {
            return await context.Carts.ToListAsync();
        }

        //to get details of particular cartitem by id
        public async Task<Carts> GetCart(int Cartid)
        {
            return await context.Carts.FirstOrDefaultAsync(c => c.Id == Cartid);
        }

        //to add cartitems
        public async Task<Carts> AddCart(Carts cart)
        {
            var result = await context.Carts.AddAsync(cart);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        //to update an existing cart
        public async Task<Carts> UpdateCart(Carts cart)
        {
            var result = await context.Carts.FirstOrDefaultAsync(c => c.Id == cart.Id);
            if (result != null)
            {
                result.Id = cart.Id;
                result.UserId = cart.UserId;
                result.ProductId = cart.ProductId;
                result.Quantity = cart.Quantity;
                result.Image= cart.Image;
                result.Brandname= cart.Brandname;
                result.Price = cart.Price;

                await context.SaveChangesAsync();
            }
            return result;
        }

        //to delete an existing cart
        public async Task<Carts> DeleteCart(int cartid)
        {
            var result = await context.Carts.FirstOrDefaultAsync(c => c.Id == cartid);
            if (result != null)
            {
                context.Carts.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
