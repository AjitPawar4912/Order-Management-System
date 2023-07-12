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
    public class UsersController : ControllerBase
    {
        private readonly IUsers userRepo;

        public UsersController(IUsers users)
        {
            this.userRepo = users;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Users>> Login(string email, string password)
        {
            try
            {
                var returnType = await userRepo.loginCheck(email, password);
                if (returnType == null)
                {
                    return StatusCode(StatusCodes.Status203NonAuthoritative, "Not Authorized");
                }
                else
                {
                    return returnType;
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Login Error......");
            }
        }
        // GET: api/Users/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            try
            {
                return (await userRepo.GetAllUsers()).ToList();
            }
            catch (Exception x)
            {
                x.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetAllUsersById(int id)
        {
            try
            {
                var result = await userRepo.GetUsers(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }


        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser(Users users)
        {
            try
            {
                if (users == null)
                {
                    return BadRequest();
                }
                var createUser = await userRepo.AddUser(users);
                return CreatedAtAction(nameof(GetAllUsersById), new { id = createUser.UserId }, createUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating new user..");
            }

        }


              //PUT: api/Users
        [HttpPut("{id}")]
        public async Task<ActionResult<Users>> UpdateUser(int id, Users users)
        {
            try
            {
                if (id != users.UserId)
                {
                    return BadRequest("UserID mismatch....");
                }
                var userToUpdate = await userRepo.GetUsers(id);
                if (userToUpdate == null)
                {
                    return NotFound("user with ID {id} not found...");
                }
                return await userRepo.UpdateUser(users);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data..");

            }
        }


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<Users> DeleteUsers(int id)
        {
            try
            {
                var userToDelete = await userRepo.GetUsers(id);
                if (userToDelete == null)
                {
                    NotFound($"user with ID {id} found");
                }
                await userRepo.DeleteUser(id);
                return userToDelete;

            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting user..");
            }
            return null;

        }


    }

    }
