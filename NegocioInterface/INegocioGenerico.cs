using System.Linq.Expressions;

namespace NegocioInterface
{
    public interface  INegocioGenerico<T>
    {
        IQueryable<T> Get();
        //IEnumerable<T> Get();
        T GetById(Expression<Func<T, bool>> predicacte);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}