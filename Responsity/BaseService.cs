using DataModel;
using IResponsity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq.Dynamic;

namespace Responsity
{
    public abstract class BaseService : IBaseResponsity, IDisposable
    {
        protected BuinessDBContext context { get; private set; }

        public BaseService(BuinessDBContext dbContext)
        {
            context = dbContext;
        }


        public T Add<T>(T t) where T : class
        {
            context.Set<T>().Add(t);
            this.SaveChanges();
            return t;
        }

        public T Delete<T>(T t) where T : class
        {
            context.Set<T>().Remove(t);
            this.SaveChanges();
            return t;
        }

        public IQueryable<T> FindByPaged<T>(Expression<Func<T, bool>> predicate, int PageIndex, int PageSzie, string OrderName, string OrderBy, out int Recordcount) where T : class
        {
            if (String.IsNullOrEmpty(OrderName))
            {
                OrderName = "BrandName";
                OrderBy = "asc";
            }
            IQueryable<T> queryLst = context.Set<T>().Where(predicate).OrderBy(OrderName + " " + OrderBy).Skip((PageIndex - 1) * PageSzie).Take(PageSzie);
            Recordcount = context.Set<T>().Where(predicate).Count();
            return queryLst;
        }

        public IQueryable<T> FindByWhere<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            IQueryable<T> queryLst = context.Set<T>().Where(predicate);
            return queryLst;
        }

        public IQueryable<T> FindAll<T>() where T : class
        {
            IQueryable<T> queryLst = null;
            queryLst = context.Set<T>();
            return queryLst;
        }

        public T Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public List<T> QueryBySql<T>(string sql, params string[] param) where T : class
        {
            if (param == null)
            {
                return context.Database.SqlQuery<T>(sql).ToList();
            }
            else
            {
                return context.Database.SqlQuery<T>(sql, param).ToList();
            }

        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void OPerationTranScope()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                this.SaveChanges();
                scope.Complete();
            }
        }

        public void ExcuteSql(string sql)
        {
            this.context.Database.ExecuteSqlCommand(sql);
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}