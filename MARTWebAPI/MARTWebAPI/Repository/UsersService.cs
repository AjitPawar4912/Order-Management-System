using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MARTWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MARTWebAPI.Repository
{
    public class UsersService : IUsers
    {
        private readonly MARTContext context;

        public UsersService(MARTContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }


        //to get details of particular user by userid
        public async Task<Users> GetUsers(int Userid)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.UserId == Userid);
        }

        //to adding new user
        public async Task<Users> AddUser(Users users)
        {
            var result = await context.Users.AddAsync(users);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        //to update an existing user
        public async Task<Users> UpdateUser(Users users)
        {
            var result = await context.Users.FirstOrDefaultAsync(u => u.UserId == users.UserId);
            if (result != null)
            {
                result.UserId = users.UserId;
                result.Firstname = users.Firstname;
                result.Lastname = users.Lastname;
                result.Emailadress = users.Emailadress;
                result.Mobilenumber = users.Mobilenumber;
                result.Address = users.Address;
                await context.SaveChangesAsync();
            }
            return result;
        }


        //to delete an existing user
        public async Task<Users> DeleteUser(int Userid)
        {
            var result = await context.Users.FirstOrDefaultAsync(u => u.UserId == Userid);
            if (result != null)
            {
                context.Users.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        //to Login details
        public async Task<Users> loginCheck(string email, string password)
        {
            Users result = await context.Users.FirstOrDefaultAsync(u => u.Emailadress == email && u.Password == password);
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
