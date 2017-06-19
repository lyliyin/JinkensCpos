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
    public class AmountDetailResponsity : BaseService, IAmountDetailResponsity
    {
        public AmountDetailResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(AmountDetail entity)
        {
            base.Add(entity);
        }

        public void Delete(AmountDetail entity)
        {
            base.Delete(entity);
        }

        public List<AmountDetail> FindList(Expression<Func<AmountDetail, bool>> predicate)
        {
            return base.FindByWhere<AmountDetail>(predicate).ToList();
        }

        public List<AmountDetail> FindList(Expression<Func<AmountDetail, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<AmountDetail>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public AmountDetail Get(Expression<Func<AmountDetail, bool>> predicate)
        {
            return base.Get<AmountDetail>(predicate);
        }

        public void Update(AmountDetail entity)
        {
            throw new NotImplementedException();
        }

        public List<T> FindListByVipId<T>(string VipId) where T : class
        {
            string sql = string.Format(@"SELECT ad.Amount,CONVERT(VARCHAR(100),ad.AmountDate, 23) as AmountDate ,u.UnitName,ss.Name
                                        FROM  AmountDetail AS ad
                                        LEFT JOIN Unit AS u ON u.Id=ad.UnitId
                                        INNER JOIN SysSources AS ss ON ss.Id=ad.AmountSourceId
                                        WHERE ad.VipId='{0}'", VipId);
            return QueryBySql<T>(sql);
        }

    }
}