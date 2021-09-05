using AutoMapper;
using DeliveryCafe.API.Interface.Auth;
using DeliveryCafe.API.Interface.DTO;
using DeliveryCafe.API.Models;
using DeliveryCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCafe.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioContext;
        private readonly IMapper _mapper;
        public IAuthService _authService;

        public UsuarioService(IUsuarioRepository usuario, IMapper mapper, IAuthService authService)
        {
            _usuarioContext = usuario;
            _mapper = mapper;
            _authService = authService;
        }

        public UsuarioDTO Insert(UsuarioDTO model)
        {
            if (model == null)
            {
                return null;
            }

            var senhaHash = _authService.ComputeSha256Hash(model.Senha);

            var usuario = _mapper.Map<Usuario>(model);
            usuario.Senha = senhaHash;
            var usuarioDTO = _usuarioContext.Insert(usuario);
            return _mapper.Map<UsuarioDTO>(usuarioDTO);

        }

        public bool Update(int id, UsuarioDTO model)
        {
            if (id == 0 || model == null)
            {
                return false;
            }
            var usuario = _mapper.Map<Usuario>(model);
            _usuarioContext.Update(id, usuario);
            return true;
        }
        public bool Delete(int id)
        {
            if (id == 0)
            {
                return false;
            }
            ;
            return _usuarioContext.Delete(id);
        }

        public List<UsuarioDTO> GetAll()
        {
            var usuarios = _usuarioContext.GetAll();
            var usuariosDTO = _mapper.Map<List<UsuarioDTO>>(usuarios);
            return usuariosDTO;

        }

        public UsuarioDTO GetById(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var usuario = _usuarioContext.GetById(id);
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return usuarioDTO;
        }

        public string Login(string email, string senha)
        {
            var senhaHash = _authService.ComputeSha256Hash(senha);

            var user =  _usuarioContext.GetUsuarioByEmailAndPassword(email, senhaHash);

            if (user == null)
            {
                return null;
            }

            return _authService.GenerateJwtToken(user.Email, user.Role);
        }
    }
}
