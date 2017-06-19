using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IVipResponsity
    {
        void Add(Vip entity);

        Vip Get(Expression<Func<Vip, bool>> predicate);

        List<Vip> FindList(Expression<Func<Vip, bool>> predicate);

        List<Vip> FindList(Expression<Func<Vip, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(Vip entity);

        void Delete(Vip entity);

        void Excutes(string sql);

        T GetVipByVipId<T>(string sql) where T : class;
    }
}
