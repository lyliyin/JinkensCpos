using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface ISysCardTypeResponsity
    {
        void Add(SysCardType entity);

        SysCardType Get(Expression<Func<SysCardType, bool>> predicate);

        List<SysCardType> FindList(Expression<Func<SysCardType, bool>> predicate);

        List<SysCardType> FindList(Expression<Func<SysCardType, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(SysCardType entity);

        void Delete(SysCardType entity);
    }
}
