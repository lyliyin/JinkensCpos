using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IVipAddressResponsity
    {
        void Add(VipAddress entity);

        VipAddress Get(Expression<Func<VipAddress, bool>> predicate);

        List<VipAddress> FindList(Expression<Func<VipAddress, bool>> predicate);

        List<VipAddress> FindList(Expression<Func<VipAddress, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(VipAddress entity);

        void Delete(VipAddress entity);
    }
}
