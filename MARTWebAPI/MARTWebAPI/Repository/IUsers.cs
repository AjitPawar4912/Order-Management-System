using MARTWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MARTWebAPI.Repository
{
    public interface IUsers
    {
        Task<IEnumerable<Users>> GetAllUsers();
        Task<Users> GetUsers(int Userid);
        Task<Users> AddUser(Users users);

        Task<Users> UpdateUser(Users users);

        Task<Users> DeleteUser(int userid);

        Task<Users> loginCheck(string email, string password);


    }
}
