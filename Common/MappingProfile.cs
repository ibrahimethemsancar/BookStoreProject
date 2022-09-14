using AutoMapper;
using webApi.Application.GenreOperations.Queries.GetGenres;
using webApi.Entities;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Queries.GetBook;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Entities;

namespace webApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book ,BookDetailViewModel>().ForMember(dest => dest.Genre , opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre , opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Genre,GenresViewModel>();
        }
    }
}