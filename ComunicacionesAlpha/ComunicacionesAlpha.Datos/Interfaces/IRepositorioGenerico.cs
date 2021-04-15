using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComunicacionesAlpha.Datos.Interfaces
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> getBy, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> Get(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          string includeProperties = "");

        TEntity GetByID(object id);

        int GetMaxId(Func<TEntity, int> columnSelector);

        void Insert(TEntity entity);

        void Update(TEntity entityToUpdate);
    }
}
