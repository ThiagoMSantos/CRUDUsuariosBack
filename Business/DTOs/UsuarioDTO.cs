using Newtonsoft.Json;
using System;

namespace Business.DTOs
{
    public class InsertUsuarioDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Escolaridade { get; set; }
    }

    public class DeleteUsuarioDTO
    {
        public string Email { get; set; }
    }

    public class UpdateUsuarioDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Escolaridade { get; set; }
    }

    public class RetornoUsuarioDTO
    {
        [JsonProperty("retornoMensagem")]
        public string mensagem { get; set; }
    }
}
