using Business.Interfaces.Repositories.Commands;
using Business.Models;
using Data.Context;

namespace Data.Repositories.Commands
{
    public class UsuarioCommandRepository : BaseCommandRepository<Usuario>, IUsuarioCommandRepository
    {
        public UsuarioCommandRepository(ConfitecContext context) : base(context)
        {

        }
    }
}
