using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Models;

namespace Business.Interfaces.Repositories.Queries
{
    public interface IBaseQueryRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity ObterPorId(Guid id);
        List<TEntity> ObterTodos();
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
    }


}