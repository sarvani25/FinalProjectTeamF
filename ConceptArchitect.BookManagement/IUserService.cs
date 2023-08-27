using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User> GetUserByEmailId(string email);

        Task<User> AddUser(User user);

        Task<User> UpdateUser(User user);

        Task DeleteUser(string email);

        Task<List<User>> SearchUsers(string term);
    }
}
