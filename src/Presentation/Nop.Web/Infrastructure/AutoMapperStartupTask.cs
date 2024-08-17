using AutoMapper;
using Nop.Core.Domain.Book;
using Nop.Core.Infrastructure;
using Nop.Web.Models.Books;

namespace Nop.Web.Infrastructure
{
    public class AutoMapperStartupTask : Profile
    {
        public AutoMapperStartupTask()
        {
            CreateMap<Books, BooksModel>()
                .ForMember(dest => dest.Name, mo => mo.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreatedOn, mo => mo.MapFrom(src => src.CreatedOn));

            CreateMap<BooksModel, Books>()
                .ForMember(dest => dest.Name, mo => mo.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreatedOn, mo => mo.Ignore());
        }

        public int Order => 0;  // This specifies the order in which this profile is applied
    }
}
