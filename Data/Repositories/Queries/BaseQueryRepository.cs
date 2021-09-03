using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Business.Interfaces.Repositories.Queries;

namespace Data.Repositories.Queries
{
    public abstract class BaseQueryRepository<TEntity> : IBaseQueryRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ConfitecContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected BaseQueryRepository(ConfitecContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).ToList();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            var lResult = this.Buscar(x => x.Id == id);
            return lResult.FirstOrDefault();
        }

        public virtual List<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

    }
}