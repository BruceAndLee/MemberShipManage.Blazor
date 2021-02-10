using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAsQuery(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void SaveChanges();
    }
}
