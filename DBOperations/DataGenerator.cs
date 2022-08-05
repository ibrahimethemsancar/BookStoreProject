using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi;

namespace webApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange( new Book{
                //Id = 1,
                Title = "Sa",
                GenreId = 1,
                PageCount = 200,
                PublishDate = new DateTime(2001,06,12)

            },
             new Book{
                //Id = 2,
                Title = "Saasdsadas",
                GenreId = 2,
                PageCount = 250,
                PublishDate = new DateTime(2002,07,22)

            });
            context.SaveChanges();
            }
        }
    }   
}