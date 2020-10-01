using AutoMapper;
using LeilaoOnline.Application.Interfaces;
using LeilaoOnline.Application.Models;
using LeilaoOnline.Domain.Entities;
using LeilaoOnline.Domain.Interfaces.Repository;
using LeilaoOnline.Domain.Interfaces.Services;

namespace LeilaoOnline.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {    
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioService usuarioService, IMapper mapper)
        {           
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
        public UsuarioModel Autenticar(UsuarioModel model)
        {
            var usuario = _mapper.Map<Usuario>(model);            
            return _mapper.Map<UsuarioModel>(_usuarioService.Autenticar(usuario)); 
        }
    }
}
