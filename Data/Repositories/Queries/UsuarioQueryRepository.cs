using System;
using System.Collections.Generic;
using System.Linq;
using Business.Interfaces.Repositories.Queries;
using Business.Models;
using Data.Context;

namespace Data.Repositories.Queries
{
    public class UsuarioQueryRepository : BaseQueryRepository<Usuario>, IUsuarioQueryRepository
    {
        public UsuarioQueryRepository(ConfitecContext context) : base(context)
        {

        }

        public Usuario ObterPorEmail(String codigoEmail)
        {
            Usuario lResult = null;

            var queryResult = this.Buscar(x => x.Email == codigoEmail);
            lResult = queryResult.FirstOrDefault();

            return lResult;
        }

        public List<Usuario> BuscarTodos()
        {
            List<Usuario> lResult = null;

            var queryResult = this.ObterTodos();
            lResult = queryResult.ToList();

            return lResult;
        }
    }
}
