using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class PersistentUserService : IUserService
    {
        IRepository<User, string> repository;

        public PersistentUserService(IRepository<User, string> repository)
        {
            this.repository = repository;
        }

        public async Task<User> AddUser(User user)
        {
            if (user == null)
                throw new InvalidDataException("User can't be null");

            return await repository.Add(user);
        }

        public async Task DeleteUser(string email)
        {
            await repository.Delete(email);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await repository.GetAll();
        }

        public async Task<User> GetUserByEmailId(string email)
        {
            return await repository.GetById(email);
        }

        public async Task<List<User>> SearchUsers(string term)
        {
            return await repository.GetAll(U => U.Email.ToLower().Contains(term.ToLower()) || U.Name.ToLower().Contains(term.ToLower()));
        }

        public async Task<User> UpdateUser(User user)
        {
            return await repository.Update(user, (old, newDetails) =>
            {
                old.Name = newDetails.Name;
                old.Password = newDetails.Password;
                old.ProfilePhoto = newDetails.ProfilePhoto;
            });
        }
    }

}
