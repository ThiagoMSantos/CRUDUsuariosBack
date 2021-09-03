using System;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Business.Interfaces.Repositories.Commands;

namespace Data.Repositories.Commands
{
  public abstract class BaseCommandRepository<TEntity> : IBaseCommandRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ConfitecContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected BaseCommandRepository(ConfitecContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity entity)
        {
           DbSet.Add(entity);
           SaveChanges();
        }

        public virtual void Atualizar(TEntity entity)
        {
            try
            {
                Db.Entry(entity).State = EntityState.Modified;
                DbSet.Update(entity);
                SaveChanges();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        public virtual void Remover(TEntity entity)
        {
            var remove = DbSet.Remove(entity);
            SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }

}