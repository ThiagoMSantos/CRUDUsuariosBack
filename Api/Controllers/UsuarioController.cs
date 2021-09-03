using Api.Controllers;
using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.Services;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Business.Notificacoes;
using Api.ViewModels;
using Business.DTOs;

namespace TesteConfitec.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _UsuarioService;

        public UsuarioController(INotificador notificador,
                                IMapper mapper,
                                IUsuarioService UsuarioService) : base(notificador)
        {
            _mapper = mapper;
            _UsuarioService = UsuarioService;
        }

        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(RetornoUsuarioDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [HttpPost("/inserir", Name = "Insere um usuário no sistema.")]
        public ActionResult InserirUsuario([FromBody] InsertUsuarioViewModel Usuario)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var response = _UsuarioService.InserirUsuario(_mapper.Map<InsertUsuarioDTO>(Usuario));

            return CustomResponse(response);
        }

        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(List<Usuario>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [HttpGet("/buscar", Name = "Retorna todos os usuários existentes no sistema.")]
        public ActionResult BuscarUsuarios()
        {
            var response = _UsuarioService.BuscarUsuarios();

            return CustomResponse(response);
        }

        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(Usuario), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [HttpGet("/buscar/{codigoEmail}", Name = "Retorna um determinado usuário existente no sistema.")]
        public ActionResult BuscarUsuario(String codigoEmail)
        {
            var response = _UsuarioService.ObterPorEmail(codigoEmail);

            return CustomResponse(response);
        }

        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(RetornoUsuarioDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [HttpPut("/alterar/{codigoEmail}", Name = "Altera os dados de um determinado usuário existente no sistema.")]
        public ActionResult BuscarUsuario(String codigoEmail, UpdateUsuarioDTO Usuario)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var response = _UsuarioService.AlterarUsuario(codigoEmail, Usuario);

            return CustomResponse(response);
        }

        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(RetornoUsuarioDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [HttpDelete("/remover/{codigoEmail}", Name = "Remove um determinado usuário existente no sistema.")]
        public ActionResult RemoverUsuario(String codigoEmail)
        {
            var response = _UsuarioService.DeletarUsuario(codigoEmail);

            return CustomResponse(response);
        }
    }
}
