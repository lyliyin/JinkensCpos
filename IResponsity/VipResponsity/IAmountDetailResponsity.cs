using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IAmountDetailResponsity
    {
        void Add(AmountDetail entity);

        AmountDetail Get(Expression<Func<AmountDetail, bool>> predicate);

        List<AmountDetail> FindList(Expression<Func<AmountDetail, bool>> predicate);

        List<AmountDetail> FindList(Expression<Func<AmountDetail, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(AmountDetail entity);

        void Delete(AmountDetail entity);

        List<T> FindListByVipId<T>(string VipId) where T : class;
    }
}
