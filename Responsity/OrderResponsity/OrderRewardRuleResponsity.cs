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
    public class OrderRewardRuleResponsity : BaseService, IOrderRewardRuleResponsity
    {
        public OrderRewardRuleResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(OrderRewardRule entity)
        {
            base.Add(entity);
        }

        public void Delete(OrderRewardRule entity)
        {
            base.Delete(entity);
        }

        public List<OrderRewardRule> FindList(Expression<Func<OrderRewardRule, bool>> predicate)
        {
            return base.FindByWhere<OrderRewardRule>(predicate).ToList();
        }

        public List<OrderRewardRule> FindList(Expression<Func<OrderRewardRule, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<OrderRewardRule>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public OrderRewardRule Get(Expression<Func<OrderRewardRule, bool>> predicate)
        {
            return base.Get<OrderRewardRule>(predicate);
        }

        public void Update(OrderRewardRule entity)
        {
            throw new NotImplementedException();
        }
    }
}
