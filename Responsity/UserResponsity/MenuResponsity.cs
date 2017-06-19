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
    public class MenuResponsity : BaseService, IMenuResponsity
    {
        public MenuResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(Menu entity)
        {
            base.Add(entity);
        }

        public void Delete(Menu entity)
        {
            base.Delete(entity);
        }

        public List<Menu> FindList(Expression<Func<Menu, bool>> predicate)
        {
            return base.FindByWhere<Menu>(predicate).ToList();
        }

        public List<Menu> FindList(Expression<Func<Menu, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<Menu>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public Menu Get(Expression<Func<Menu, bool>> predicate)
        {
            return base.Get<Menu>(predicate);
        }

        public void Update(Menu entity)
        {
            throw new NotImplementedException();
        }
    }
}
