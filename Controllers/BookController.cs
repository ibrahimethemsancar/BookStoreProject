using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using webApi.BookOperations.CreateBook;
using webApi.DBOperations;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController (BookStoreDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBooks(){
            GetBooksQuery query = new GetBooksQuery(_context , _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById( int id)
        {
          BookDetailViewModel result ;
            GetBookDetailQuery query = new GetBookDetailQuery(_context , _mapper);
            try
            {
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

    //       [HttpGet]
    //     public Book Get([FromQuery]string id)
    //     {
    //         var singleBook = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
    //         return singleBook;
    //     }

    //http POST

    [HttpPost]
    public ActionResult AddBook([FromQuery] CreateBookModel  newBook)
    {
        CreateBookCommand command = new CreateBookCommand(_context , _mapper);
        try
        {
        command.Model = newBook;
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        ValidationResult result = validator.Validate(command);
        validator.ValidateAndThrow(command);
        command.Handle();
        // if(!result.IsValid)
        // {
        //     foreach (var item in result.Errors)
        //     {
        //         Console.WriteLine("Property :" + item.PropertyName + "- Error Message :" + item.ErrorMessage);
        //     }
        // }
        // else{
        // command.Handle();    
        // }


        
        }
        catch (Exception ex)
        {
            
            return BadRequest(ex.Message);
        }
        
       
       
        return Ok();
    }

    //HTTP PUT
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id , UpdateBookModel updatedBook)
    {
        try
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.Model = updatedBook;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
        }
        catch (Exception ex)
        {
            
            return BadRequest(ex.Message);
        }
            
            return Ok();
    }

    //HTTP DELETE Process

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        try
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
        }
        catch (Exception ex)
        {
            
            return BadRequest(ex.Message);
        }
        return Ok();
    }


    }

}