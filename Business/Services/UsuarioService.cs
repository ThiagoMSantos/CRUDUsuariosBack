using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Business.Interfaces.Repositories.Commands;
using Business.Interfaces.Repositories.Queries;
using Business.Interfaces.Services;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IMapper _mapper;
        IUsuarioCommandRepository _UsuarioCommandRepository;
        IUsuarioQueryRepository _UsuarioQueryRepository;

        public UsuarioService(INotificador notificador,
                            IUsuarioCommandRepository UsuarioCommandRepository,
                            IUsuarioQueryRepository UsuarioQueryRepository,
                            IMapper mapper) : base(notificador)
        {
            _UsuarioCommandRepository = UsuarioCommandRepository;
            _UsuarioQueryRepository = UsuarioQueryRepository;
            _mapper = mapper;
        }

        public List<Usuario> BuscarUsuarios()
        {
            var Usuarios = _UsuarioQueryRepository.ObterTodos();
            if (Usuarios.Any())
            {
                return Usuarios;
            }
            else
            {
                Notificar("Não há nenhum Usuario cadastrado.");
                return null;
            }
        }

        public Usuario ObterPorEmail(String codigoEmail)
        {
            var UsuarioEncontrado = _UsuarioQueryRepository.ObterPorEmail(codigoEmail);
            if (UsuarioEncontrado != null)
            {
                return UsuarioEncontrado;
            }
            else
            {
                Notificar("Usuario não encontrado no sistema.");
                return null;
            }
        }

        public RetornoUsuarioDTO InserirUsuario(InsertUsuarioDTO UsuarioInsert)
        {
            var UsuarioValida = _UsuarioQueryRepository.ObterPorEmail(UsuarioInsert.Email);
            if (UsuarioValida == null)
            {
                Usuario UsuarioModel = _mapper.Map<Usuario>(UsuarioInsert);
                _UsuarioCommandRepository.Adicionar(UsuarioModel);
                return new RetornoUsuarioDTO
                {
                    mensagem = "Usuario inserido com sucesso."
                };
            }
            else
            {
                Notificar("Esse usuário já esta cadastrado no sistema.");
                return new RetornoUsuarioDTO
                {
                    mensagem = "Esse usuário já esta cadastrado no sistema."
                };
            }

        }
        public RetornoUsuarioDTO AlterarUsuario(String email, UpdateUsuarioDTO UsuarioAlterado)
        {
            var UsuarioModel = _mapper.Map<Usuario>(UsuarioAlterado);
            var UsuarioExistente = _UsuarioQueryRepository.ObterPorEmail(email);

            //Atualizando dados
            UsuarioExistente.DataNascimento = Convert.ToDateTime(UsuarioAlterado.DataNascimento);
            UsuarioExistente.Email = UsuarioAlterado.Email;
            UsuarioExistente.Escolaridade = UsuarioAlterado.Escolaridade;
            UsuarioExistente.Nome = UsuarioAlterado.Nome;
            UsuarioExistente.Sobrenome = UsuarioAlterado.Sobrenome;

            if (UsuarioExistente != null)
            {
                _UsuarioCommandRepository.Atualizar(UsuarioExistente);
                return new RetornoUsuarioDTO
                {
                    mensagem = "Usuario alterado com sucesso."
                };
            }
            else
            {
                Notificar("Usuario não encontrado no sistema.");
                return null;
            }

        }

        public RetornoUsuarioDTO DeletarUsuario(String codigoEmail)
        {
            var UsuarioDeletado = _UsuarioQueryRepository.ObterPorEmail(codigoEmail);
            if(UsuarioDeletado != null)
            {
                _UsuarioCommandRepository.Remover(UsuarioDeletado);
                return new RetornoUsuarioDTO
                {
                    mensagem = "Usuario Deletado com sucesso."
                };
            }
            else
            {
                Notificar("Usuario não encontrado no sistema.");
                return null;
            }

        }

    }
}
