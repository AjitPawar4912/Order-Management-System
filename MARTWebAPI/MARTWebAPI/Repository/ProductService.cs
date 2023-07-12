using MARTWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARTWebAPI.Repository
{
    public class ProductService:IProduct
    {
        private readonly MARTContext context;

        public ProductService(MARTContext context)
        {
            this.context = context;
        }

        //to get details of all products
        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            return await context.Products.ToListAsync();
        }

        //to get details of particular product by productid
        public async Task<Products> GetProduct(int Productid)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.ProductId == Productid);
        }

        public async Task<Products> AddProduct(Products product)
        {
            var result = await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        //to update an existing product
        public async Task<Products> UpdateProduct(Products product)
        {
            var result = await context.Products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);
            if (result != null)
            {
                result.ProductId = product.ProductId;
                result.Name = product.Name;
                result.Brandname = product.Brandname;
                result.Category = product.Category;
                result.Price = product.Price;
                result.Image = product.Image;
                result.Description = product.Description;
                await context.SaveChangesAsync();
            }
            return result;
        }

        //to delete an existing product
        public async Task<Products> DeleteProduct(int productid)
        {
            var result = await context.Products.FirstOrDefaultAsync(p => p.ProductId == productid);
            if (result != null)
            {
                context.Products.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}
