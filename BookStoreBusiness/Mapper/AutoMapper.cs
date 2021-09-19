using System;
using AutoMapper;
using BookStoreBusiness;
using BookStoreDataAccess;
using Ninject.Modules;

namespace BookStoreConsole.Mapper
{
    public class BookAutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookEntity>()
                .ForMember(dest => dest.PublishYear,
                    opt => opt.MapFrom(src => Convert.ToInt32(src.PublishYear)))
                .ForMember(dest => dest.Price,
                    opt => opt.MapFrom(src => Convert.ToInt32(src.Price)))
                .ForMember(dest => dest.BookCategory,
                    opt => opt.MapFrom(src => GetBookCategory(src.Price))).ReverseMap());

            Bind<IMapper>().ToConstructor(c => new AutoMapper.Mapper(mapperConfiguration)).InSingletonScope(); 
        }

        private PriceCategory GetBookCategory(string srcPrice)
        {
            var price = Convert.ToInt32(srcPrice);
            if (price <= 100)
            {
                return PriceCategory.Cheap;
            }

            if (price >= 1000)
            {
                return PriceCategory.Expensive;
            }

            return PriceCategory.Normal;
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();   
            });

            return config;
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookEntity>()
                .ForMember(dest => dest.PublishYear,
                    opt => opt.MapFrom(src => Convert.ToInt32(src.PublishYear)))
                .ForMember(dest => dest.Price,
                    opt => opt.MapFrom(src => Convert.ToInt32(src.Price)))
                .ForMember(dest => dest.BookCategory,
                    opt => opt.MapFrom(src => GetBookCategory(src.Price))).ReverseMap();
        }

        private PriceCategory GetBookCategory(string srcPrice)
        {
            var price = Convert.ToInt32(srcPrice);
            if (price <= 100)
            {
                return PriceCategory.Cheap;
            }

            if (price >= 1000)
            {
                return PriceCategory.Expensive;
            }

            return PriceCategory.Normal;
        }
    }
}
