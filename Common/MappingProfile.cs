using System.Threading.Tasks.Dataflow;
using AutoMapper;
using WebApi;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;

namespace webApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book ,BookDetailViewModel>().ForMember(dest => dest.Genre , opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre , opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}