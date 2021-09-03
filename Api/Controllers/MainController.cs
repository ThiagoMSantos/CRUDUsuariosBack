using System.Linq;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Business.Notificacoes;

namespace Api.Controllers
{
    public class MainController : ControllerBase
    {
        private readonly INotificador _notificador;


        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida() => !_notificador.TemNotificacao();

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                if (result != null)
                {
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
            }

            return BadRequest(new
            {
                sucess = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in errors)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string errorMsg) => _notificador.Handle(new Notificacao(errorMsg));
    }
}
