 using System;
using System.Linq;
using System.Reflection.Metadata;
using webApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;
        public int  BookId;
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
                _context = dbContext;
        }

        public void Handle()
        {
            
        var book = _context.Books.SingleOrDefault(item => item.Id ==BookId);
        if(book is null){
            throw new  InvalidOperationException("The book have likes this id is not found");
        }
        _context.Books.Remove(book);

        _context.SaveChanges();
        }
    }

}