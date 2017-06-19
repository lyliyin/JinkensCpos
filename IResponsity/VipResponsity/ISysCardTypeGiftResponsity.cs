using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface ISysCardTypeGiftResponsity
    {
        void Add(SysCardTypeGift entity);

        SysCardTypeGift Get(Expression<Func<SysCardTypeGift, bool>> predicate);

        List<SysCardTypeGift> FindList(Expression<Func<SysCardTypeGift, bool>> predicate);

        List<CouponCategory> FindImagesList(string CardTypeId);

        List<SysCardTypeGift> FindList(Expression<Func<SysCardTypeGift, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(SysCardTypeGift entity);

        void Delete(SysCardTypeGift entity);
    }
}
