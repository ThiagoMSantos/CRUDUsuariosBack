using Business.Models;
using System;
using System.Collections.Generic;

namespace Business.Interfaces.Repositories.Queries
{
    public interface IUsuarioQueryRepository : IBaseQueryRepository<Usuario>
    {
        public Usuario ObterPorEmail(String codigoEmail);
        public List<Usuario> BuscarTodos();
    }
}
