using Api.ViewModels;
using AutoMapper;
using Business.DTOs;
using Business.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configuration
{
    public class AutoMapperConfig
    {
        public static void ResolveAutoMapper(IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                //Usuario
                cfg.CreateMap<InsertUsuarioViewModel, InsertUsuarioDTO>().ReverseMap();
                cfg.CreateMap<UpdateUsuarioViewModel, UpdateUsuarioDTO>().ReverseMap();
                cfg.CreateMap<DeleteUsuarioViewModel, DeleteUsuarioDTO>().ReverseMap();
                cfg.CreateMap<Usuario, InsertUsuarioDTO>().ReverseMap();
                cfg.CreateMap<Usuario, UpdateUsuarioDTO>().ReverseMap();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}