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
    public class SysCardTypeResponsity : BaseService, ISysCardTypeResponsity
    {
        public SysCardTypeResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(SysCardType entity)
        {
            base.Add(entity);
        }

        public void Delete(SysCardType entity)
        {
            base.Delete(entity);
        }

        public List<SysCardType> FindList(Expression<Func<SysCardType, bool>> predicate)
        {
            return base.FindByWhere<SysCardType>(predicate).ToList();
        }

        public List<SysCardType> FindList(Expression<Func<SysCardType, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<SysCardType>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public SysCardType Get(Expression<Func<SysCardType, bool>> predicate)
        {
            return base.Get<SysCardType>(predicate);
        }

        public void Update(SysCardType entity)
        {
            throw new NotImplementedException();
        }
    }
}