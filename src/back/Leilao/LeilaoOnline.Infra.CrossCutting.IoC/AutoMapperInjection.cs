using AutoMapper;
using LeilaoOnline.Application.Models;
using LeilaoOnline.Domain.Entities;
using System;

namespace LeilaoOnline.Infra.CrossCutting.IoC
{
    public class AutoMapperInjection
    {
        public static MapperConfiguration Config()
        {
            return new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
                cfg.CreateMap<string, DateTime>().ConvertUsing(s => Convert.ToDateTime(s));

                cfg.CreateMap<int, string>().ConvertUsing(i => i.ToString());
                cfg.CreateMap<DateTime, string>().ConvertUsing(d => string.Format("{0:s}", d));

                cfg.CreateMap<UsuarioModel, Usuario>();
                cfg.CreateMap<Usuario, UsuarioModel>();

                cfg.CreateMap<Leilao, LeilaoModel>()
                          .ForMember(dest => dest.Usuario, opt => opt.MapFrom(x => x.Usuario.Nome));

                cfg.CreateMap<LeilaoModel, Leilao>();
            });
        }
    }
}
