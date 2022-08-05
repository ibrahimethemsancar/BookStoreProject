using System;
using System.Linq;
using webApi.DBOperations;

namespace WebApi.BookOperations.CreateBook
{
   
    public class CreateBookCommand
    {
        public CreateBookModel Model{get;set;}
        private readonly BookStoreDbContext _dbContext;
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
        if(book is not null){
            throw new InvalidOperationException("The book is already saved");

        }
        book = new Book();
        book.Title = Model.Title;
        book.PageCount = Model.PageCount;
        book.GenreId = Model.GenreId;
        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();//

        }
       
    }
     public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PuslishDate { get; set; }
        }
}