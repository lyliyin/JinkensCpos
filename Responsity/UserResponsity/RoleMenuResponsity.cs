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
    public class RoleMenuResponsity : BaseService, IRoleMenuResponsity
    {
        public RoleMenuResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(RoleMenu entity)
        {
            base.Add(entity);
        }

        public void Delete(RoleMenu entity)
        {
            base.Delete(entity);
        }

        public List<RoleMenu> FindList(Expression<Func<RoleMenu, bool>> predicate)
        {
            return base.FindByWhere<RoleMenu>(predicate).ToList();
        }

        public List<RoleMenu> FindList(Expression<Func<RoleMenu, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<RoleMenu>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public RoleMenu Get(Expression<Func<RoleMenu, bool>> predicate)
        {
            return base.Get<RoleMenu>(predicate);
        }

        public void Update(RoleMenu entity)
        {
            throw new NotImplementedException();
        }
    }
}
