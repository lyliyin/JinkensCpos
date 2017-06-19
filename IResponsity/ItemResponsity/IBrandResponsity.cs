using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface IBrandResponsity
    {
        void Add(Brand entity);

        Brand Get(Expression<Func<Brand, bool>> predicate);

        List<Brand> FindList(Expression<Func<Brand, bool>> predicate);

        List<Brand> FindList(Expression<Func<Brand, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(Brand entity);

        void Delete(Brand entity);

        void Save();
    }
}
