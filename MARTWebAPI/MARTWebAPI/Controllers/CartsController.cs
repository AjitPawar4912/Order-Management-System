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
    public class CartsController : ControllerBase
    {
        private readonly ICart cartRepo;

        public CartsController(ICart cartRepo)
        {
            this.cartRepo = cartRepo;
        }

        // GET: api/Cart/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carts>>> GetAllCart()
        {
            try
            {
                return (await cartRepo.GetAllCart()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        // GET: api/Cart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carts>> GetAllCartById(int id)
        {
            try
            {
                var result = await cartRepo.GetCart(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: api/Cart
        [HttpPost]
        public async Task<ActionResult<Carts>> CreateCart(Carts cart)
        {
            try
            {
                if (cart != null)
                {
                    return BadRequest();
                }
                var createCart = await cartRepo.AddCart(cart);
                return CreatedAtAction(nameof(GetAllCartById), new { id = createCart.Id }, createCart);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating new orderitems.");
            }

        }

        //PUT: api/Cart
        [HttpPut("{id}")]
        public async Task<ActionResult<Carts>> UpdateCart(int id, Carts cart)
        {
            try
            {
                if (id != cart.Id)
                {
                    return BadRequest("Cart ID mismatch....");
                }
                var cartToUpdate = await cartRepo.GetCart(id);
                if (cartToUpdate == null)
                {
                    return NotFound("cart items with ID {id} not found...");
                }
                return await cartRepo.UpdateCart(cart);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data..");

            }
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public async Task<Carts> DeleteCart(int id)
        {
            try
            {
                var cartToDelete = await cartRepo.GetCart(id);
                if (cartToDelete == null)
                {
                    NotFound($"....cart item with ID {id} found....");
                }
                await cartRepo.DeleteCart(id);
                return cartToDelete;

            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting cart items..");
            }
            return null;

        }
    }

}