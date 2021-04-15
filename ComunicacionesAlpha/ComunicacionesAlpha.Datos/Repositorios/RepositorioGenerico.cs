using ComunicacionesAlpha.Datos.Interfaces;
using ComunicacionesAlpha.Infraestructura.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComunicacionesAlpha.Datos
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class
    {
        internal ContextoBD _contexto;
        internal DbSet<TEntity> dbSet;

        public RepositorioGenerico(ContextoBD contexto)
        {
            this._contexto = contexto;
            this.dbSet = _contexto.Set<TEntity>();
        }

        public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> getBy, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = _contexto.Set<TEntity>().Where(getBy);

            foreach (var expression in includes)
                result = result.Include(expression);

            return await result.ToListAsync();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var propiedad in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(propiedad);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public int GetMaxId(Func<TEntity, int> columnSelector)
        {
            var GetMaxId = _contexto.Set<TEntity>().Max(columnSelector);
            return GetMaxId;
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _contexto.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
