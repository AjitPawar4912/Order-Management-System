using MARTWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARTWebAPI.Repository
{
     public interface IProduct
    {
        Task<IEnumerable<Products>> GetAllProducts();

      
        Task<Products> GetProduct(int Productid);
        Task<Products> AddProduct(Products product);
        Task<Products> UpdateProduct(Products product);
        Task<Products> DeleteProduct(int productid);

    }
}
