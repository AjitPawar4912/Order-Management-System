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
    public class SellerController : ControllerBase
    {
        private readonly ISeller sellerRepo;

        public SellerController(ISeller seller)
        {
            this.sellerRepo = seller;
        }

        // GET: api/Seller/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seller>>> GetAllSellers()
        {
            try
            {
                return (await sellerRepo.GetAllSellers()).ToList();
            }
            catch (Exception x)
            {
                x.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/Seller/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seller>> GetAllSellersById(int id)
        {
            try
            {
                var result = await sellerRepo.GetSeller(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        // POST: api/Seller
        [HttpPost]
        public async Task<ActionResult<Seller>> CreateSeller(Seller Seller)
        {
            try
            {
                if (Seller == null)
                {
                    return BadRequest();
                }
                var createSeller = await sellerRepo.AddSeller(Seller);
                return CreatedAtAction(nameof(GetAllSellersById), new { id = createSeller.Id }, createSeller);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating new user..");
            }

        }


        //PUT: api/Seller
        [HttpPut("{id}")]
        public async Task<ActionResult<Seller>> UpdateSeller(int id, Seller Seller)
        {
            try
            {
                if (id != Seller.Id)
                {
                    return BadRequest("UserID mismatch....");
                }
                var sellerToUpdate = await sellerRepo.GetSeller(id);
                if (sellerToUpdate == null)
                {
                    return NotFound("user with ID {id} not found...");
                }
                return await sellerRepo.UpdateSeller(Seller);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data..");

            }
        }


        // DELETE: api/Seller/5
        [HttpDelete("{id}")]
        public async Task<Seller> DeleteSeller(int id)
        {
            try
            {
                var sellerToDelete = await sellerRepo.GetSeller(id);
                if (sellerToDelete == null)
                {
                    NotFound($"user with ID {id} found");
                }
                await sellerRepo.DeleteSeller(id);
                return sellerToDelete;

            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting seller..");
            }
            return null;

        }


    }

}

