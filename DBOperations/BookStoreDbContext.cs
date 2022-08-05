using Microsoft.EntityFrameworkCore;
using WebApi;

namespace webApi.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books {get;set;}
    }
}