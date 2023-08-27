using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.Repositories.EFRepository
{
    public class EFUserRepository : IRepository<User, string>
    {
        BMSContext context;
        public EFUserRepository(BMSContext context)
        {
            this.context = context;
        }

        public async Task<User> Add(User entity)
        {
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(string id)
        {
           var user = await GetById(id);
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            await Task.CompletedTask;
            return context.Users.ToList();
        }

        public async Task<List<User>> GetAll(Func<User, bool> predicate)
        {
            await Task.CompletedTask;
            var q = from user in context.Users
                    where predicate(user)
                    select user;
            return q.ToList();
        }

        public async Task<User> GetById(string id)
        {
            await Task.CompletedTask;
            return context.Users.FirstOrDefault(u => u.Email==id);
        }

        public async Task<User> Update(User entity, Action<User, User> mergeOldNew)
        {
            var user = await GetById(entity.Email);
            if(user != null)
            {
                mergeOldNew(user, entity);
                await context.SaveChangesAsync();
            }
            return user;
        }
    }
}
