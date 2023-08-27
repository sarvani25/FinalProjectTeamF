using ConceptArchitect.BookManagement;
using ConceptArchitect.BookManagement.Repositories.EFRepository;
using ConceptArchitect.Utils;
using Microsoft.EntityFrameworkCore;

namespace BooksWeb02.Extensions
{
    public static class EFRepositoryExtensions
    {
        public static IServiceCollection AddEFBmsRepository(this IServiceCollection services)
        {
            services.AddDbContext<BMSContext>((serviceProvider, contextBuilder) =>
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                var connectionString = config.GetConnectionString("EFContext");
                contextBuilder.UseSqlServer(connectionString);
            });

            services.AddTransient<IRepository<Author, string>, EFAuthorRepository>();
            services.AddTransient<IRepository<Book, string>, EFBookRepository>();
            services.AddTransient<IRepository<User, string>, EFUserRepository>();
            services.AddTransient<IRepository<Review, int>, EFReviewRepository>();
            services.AddTransient<IRepository<Favorite, int>, EFFavoriteRepository>();


            return services;
        }
    }
}
