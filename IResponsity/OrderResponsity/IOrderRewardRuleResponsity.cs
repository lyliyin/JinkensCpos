using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IOrderRewardRuleResponsity
    {
        void Add(OrderRewardRule entity);

        OrderRewardRule Get(Expression<Func<OrderRewardRule, bool>> predicate);

        List<OrderRewardRule> FindList(Expression<Func<OrderRewardRule, bool>> predicate);

        List<OrderRewardRule> FindList(Expression<Func<OrderRewardRule, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(OrderRewardRule entity);

        void Delete(OrderRewardRule entity);
    }
}

