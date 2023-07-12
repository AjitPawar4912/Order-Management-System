using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MARTWebAPI.Models;
using MARTWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MARTWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct productRepo;

        public ProductsController(IProduct productRepo)
        {
            this.productRepo = productRepo;
        }

        // GET: api/Product/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetAllProducts()
        {
            try
            {
                return (await productRepo.GetAllProducts()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetAllProductsById(int id)
        {
            try
            {
                var result = await productRepo.GetProduct(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Products>> CreateProduct(Products product)
        {
            try
            {
                if (product != null)
                {
                    return BadRequest();
                }
                var createProduct = await productRepo.AddProduct(product);
                return CreatedAtAction(nameof(GetAllProductsById), new { id = createProduct.ProductId }, createProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating new product..");
            }

        }

        //PUT: api/Product
        [HttpPut("{id}")]
        public async Task<ActionResult<Products>> UpdateProduct(int id, Products product)
        {
            try
            {
                if (id != product.ProductId)
                {
                    return BadRequest("ProductID mismatch....");
                }
                var productToUpdate = await productRepo.GetProduct(id);
                if (productToUpdate == null)
                {
                    return NotFound("product with ID {id} not found...");
                }
                return await productRepo.UpdateProduct(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data..");

            }
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<Products> DeleteProduct(int id)
        {
            try
            {
                var productToDelete = await productRepo.GetProduct(id);
                if (productToDelete == null)
                {
                    NotFound($"Product with ID {id} found");
                }
                await productRepo.DeleteProduct(id);
                return productToDelete;

            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting product..");
            }
            return null;

        }
    }
}