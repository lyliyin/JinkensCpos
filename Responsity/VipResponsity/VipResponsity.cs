using DataModel;
using DataModel.GeneralModel;
using IResponsity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Responsity
{
    public class VipsResponsity : BaseService, IVipResponsity
    {
        public VipsResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(Vip entity)
        {
            base.Add(entity);
        }

        public void Delete(Vip entity)
        {
            base.Delete(entity);
        }

        public List<Vip> FindList(Expression<Func<Vip, bool>> predicate)
        {
            return base.FindByWhere<Vip>(predicate).ToList();
        }

        public List<Vip> FindList(Expression<Func<Vip, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<Vip>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public Vip Get(Expression<Func<Vip, bool>> predicate)
        {
            return base.Get<Vip>(predicate);
        }

        public T GetVipByVipId<T>(string sql) where T : class
        {
            return base.QueryBySql<T>(sql).FirstOrDefault();
        }

        public void Excutes(string sql)
        {
            base.ExcuteSql(sql);
        }

        public void Update(Vip entity)
        {
            throw new NotImplementedException();
        }
    }
}