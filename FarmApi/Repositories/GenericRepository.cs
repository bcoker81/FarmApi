using FarmApi.Data;
using FarmApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FarmApi.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private FarmDbContext _context;
        public GenericRepository(FarmDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {

            return _context.Set<TEntity>().ToList();

        }

        public TEntity FindById(int id)
        {

            return _context.Set<TEntity>().Find(id);

        }

        public TEntity Add(TEntity entity)
        {

            _context.Set<TEntity>().Add(entity);
            return entity;

        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {

            _context.Set<TEntity>().AddRange(entities);
            return entities;

        }

        public void Remove(TEntity entity)
        {

            _context.Set<TEntity>().Remove(entity);

        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            
                _context.Set<TEntity>().RemoveRange(entities);
            
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }
    }
}