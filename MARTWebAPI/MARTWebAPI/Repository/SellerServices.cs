using MARTWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARTWebAPI.Repository
{
    public class SellerServices:ISeller
    {
        private readonly MARTContext context;

        public SellerServices(MARTContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Seller>> GetAllSellers()
        {
            return await context.Seller.ToListAsync();
        }


        
        public async Task<Seller> GetSeller(int sellerid)
        {
            return await context.Seller.FirstOrDefaultAsync(u => u.Id == sellerid);
        }

       
        public async Task<Seller> AddSeller(Seller seller)
        {
            var result = await context.Seller.AddAsync(seller);
            await context.SaveChangesAsync();
            return result.Entity;
        }

      
        public async Task<Seller> UpdateSeller(Seller seller)
        {
            var result = await context.Seller.FirstOrDefaultAsync(u => u.Id == seller.Id);
            if (result != null)
            {
                result.Id = seller.Id;
                result.Sname = seller.Sname;
                result.Emailadress = seller.Emailadress;
                result.Mobilenumber = seller.Mobilenumber;
                result.Password = seller.Password;
                result.Address = seller.Address;
                await context.SaveChangesAsync();
            }
            return result;
        }


    
        public async Task<Seller> DeleteSeller(int sellerid)
        {
            var result = await context.Seller.FirstOrDefaultAsync(u => u.Id == sellerid);
            if (result != null)
            {
                context.Seller.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

       
    }
}
