using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels
{
    public class InsertUsuarioViewModel
    {
        [Required(ErrorMessage = "Insira o seu primeiro nome.")]
        [JsonProperty("nomeUsuario")]
        public string Nome { get; set; }

        [JsonProperty("sobrenomeUsuario")]
        public string Sobrenome { get; set; }

        [RegularExpression(@"^(([^<>()\[\]\\.,;:\s@']+(\.[^<>()\[\]\\.,;:\s@']+)*)|('.+'))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "E-mail em formato inválido.")]
        [Required(ErrorMessage = "Insira o seu e-mail.")]
        [JsonProperty("codigoEmail")]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Insira a sua data de nascimento.")]
        [JsonProperty("dataNascimento")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Insira o seu grau de Escolaridade.")]
        [JsonProperty("grauEscolaridade")]
        public string Escolaridade { get; set; }
    }

    public class DeleteUsuarioViewModel
    {
        [Required(ErrorMessage = "Insira o e-mail do usuário que será deletado.")]
        [JsonProperty("codigoEmail")]
        public string Email { get; set; }
    }

    public class UpdateUsuarioViewModel
    {
        [Required(ErrorMessage = "Insira o seu primeiro nome.")]
        [JsonProperty("nomeUsuario")]
        public string Nome { get; set; }

        [JsonProperty("sobrenomeUsuario")]
        public string Sobrenome { get; set; }

        [RegularExpression(@"^(([^<>()\[\]\\.,;:\s@']+(\.[^<>()\[\]\\.,;:\s@']+)*)|('.+'))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "E-mail em formato inválido.")]
        [Required(ErrorMessage = "Insira o seu e-mail.")]
        [JsonProperty("codigoEmail")]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Insira a sua data de nascimento.")]
        [JsonProperty("dataNascimento")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Insira o seu grau de Escolaridade.")]
        [JsonProperty("grauEscolaridade")]
        public string Escolaridade { get; set; }
    }
}
