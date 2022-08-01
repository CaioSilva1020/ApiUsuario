using AcessoDados;
using Microsoft.EntityFrameworkCore;
using NegocioInterface;
using System.Linq.Expressions;

namespace Negocio
{
    public class NegocioGenerico<T> : INegocioGenerico<T> where T : class
    {
        private MyDbContext _context;
        protected NegocioGenerico()
        {
            try
            {
                _context = new MyDbContext();

            }
            catch (Exception ex) { throw ex; }
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
        //public IEnumerable<T> Get()
        //{
        //    return _context.Set<T>().AsEnumerable<T>();
        //}
        //public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        //{
        //    return _context.Set<T>().Where(predicate).AsEnumerable<T>();
        //}
        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }
    }
}