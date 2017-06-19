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
    public class SysCardTypeGiftResponsity : BaseService, ISysCardTypeGiftResponsity
    {
        public SysCardTypeGiftResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(SysCardTypeGift entity)
        {
            base.Add(entity);
        }

        public void Delete(SysCardTypeGift entity)
        {
            base.Delete(entity);
        }

        public List<CouponCategory> FindImagesList(string CardTypeId)
        {
            string sql = string.Format(@"SELECT cc.* FROM SysCardTypeGift AS sctg
                                        INNER JOIN CouponCategory AS cc ON cc.CouponCategoryId = sctg.CouponCategoryId
                                        WHERE sctg.SysCardTypeId = '{0}'", CardTypeId);
            return base.QueryBySql<CouponCategory>(sql);
        }

        public List<SysCardTypeGift> FindList(Expression<Func<SysCardTypeGift, bool>> predicate)
        {
            return base.FindByWhere<SysCardTypeGift>(predicate).ToList();
        }

        public List<SysCardTypeGift> FindList(Expression<Func<SysCardTypeGift, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<SysCardTypeGift>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public SysCardTypeGift Get(Expression<Func<SysCardTypeGift, bool>> predicate)
        {
            return base.Get<SysCardTypeGift>(predicate);
        }

        public void Update(SysCardTypeGift entity)
        {
            throw new NotImplementedException();
        }
    }
}