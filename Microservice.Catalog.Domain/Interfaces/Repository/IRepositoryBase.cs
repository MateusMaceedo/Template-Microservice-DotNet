using Microservice.Catalog.Domain.Entities.Base;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace Microservice.Catalog.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity>
    where TEntity : Entity
    {
        TEntity Buscar(string id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> query);
        TEntity Inserir(TEntity entity);
        void Inserir(IEnumerable<TEntity> entities);
        void Alterar(string id, TEntity entity);
        void Remover(TEntity entity);
        void Remover(string id);
    }
}
