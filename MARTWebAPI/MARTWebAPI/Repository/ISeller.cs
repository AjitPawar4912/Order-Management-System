using MARTWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARTWebAPI.Repository
{
     public interface ISeller
    {
        Task<IEnumerable<Seller>> GetAllSellers();
        Task<Seller> GetSeller(int id);
        Task<Seller> AddSeller(Seller seller);

        Task<Seller> UpdateSeller(Seller seller);

        Task<Seller> DeleteSeller(int sellerid);
    }
}
