using Business.DTOs;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface IUsuarioService
    {
        List<Usuario> BuscarUsuarios();
        Usuario ObterPorEmail(String cdEmail);
        RetornoUsuarioDTO InserirUsuario(InsertUsuarioDTO usuario);
        RetornoUsuarioDTO AlterarUsuario(String email, UpdateUsuarioDTO UsuarioAlterado);
        RetornoUsuarioDTO DeletarUsuario(String codigoEmail);
    }
}
