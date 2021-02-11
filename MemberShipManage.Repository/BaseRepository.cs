using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using MemberShipManage.Infrastructurer;
using Microsoft.Data.SqlClient;
using MemberShipManage.Infrastructurer.Extension;

namespace MemberShipManage.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            T existing = _unitOfWork.Context.Set<T>().Find(entity);
            if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);
        }

        public IEnumerable<T> Get()
        {
            return _unitOfWork.Context.Set<T>().AsEnumerable<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public IQueryable<T> GetAsQuery(Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().FirstOrDefault(predicate);
        }

        public void Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
        }

        public List<T> ExecuteSqlQuery(string sqlScript, SqlParameter[] sqlParams)
        {
            List<T> result = _unitOfWork.Context.Database.SqlQuery<T>(sqlScript, sqlParams);
            return result != null ? result.ToList() : null;
        }

        public List<F> ExecuteSqlQuery<F>(string sqlScript, SqlParameter[] sqlParams) where F : class, new()
        {
            List<F> result = _unitOfWork.Context.Database.SqlQuery(sqlScript, sqlParams).ToList<F>();
            return result != null ? result.ToList() : null;
        }

        public int ExecuteSqlCommand(string sqlScript, SqlParameter[] sqlParams)
        {
            return _unitOfWork.Context.Database.ExecuteSqlRaw(sqlScript, sqlParams);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
