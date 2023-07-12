using MARTWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARTWebAPI.Repository
{
     public interface ICart
    {

        Task<IEnumerable<Carts>> GetAllCart();
        Task<Carts> GetCart(int Cartid);
        Task<Carts> AddCart(Carts cart);
        Task<Carts> UpdateCart(Carts cart);
        Task<Carts> DeleteCart(int cartid);
    }
}
