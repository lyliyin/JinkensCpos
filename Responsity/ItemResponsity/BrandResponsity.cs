using IResponsity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.GeneralModel;
using System.Linq.Expressions;
using DataModel;

namespace Responsity
{
    public class BrandResponsity : BaseService, IBrandResponsity
    {
        public BrandResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }


        public void Add(Brand entity)
        {
            base.Add(entity);
        }

        public void Delete(Brand entity)
        {
            base.Delete(entity);
        }

        public List<Brand> FindList(Expression<Func<Brand, bool>> predicate)
        {
            return base.FindByWhere<Brand>(predicate).ToList();
        }

        public List<Brand> FindList(Expression<Func<Brand, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            List<Brand> lst = base.FindByPaged<Brand>(predicate, PageIndex, PageSize,OrderName,OrderBy,out recordCount).ToList();
            return lst;
        }

        public Brand Get(Expression<Func<Brand, bool>> predicate)
        {
            return base.Get<Brand>(predicate);
        }

        public void Save()
        {
            base.SaveChanges();
        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
