using System;
using Business.Models;

namespace Business.Interfaces.Repositories.Commands
{
    public interface IBaseCommandRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
        int SaveChanges();
    }

}