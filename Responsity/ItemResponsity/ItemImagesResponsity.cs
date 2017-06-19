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
    public class ItemImagesResponsity : BaseService, IItemImagesResponsity
    {
        public ItemImagesResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(ItemImages entity)
        {
            base.Add(entity);
        }

        public void Delete(ItemImages entity)
        {
            base.Delete(entity);
        }

        public List<ItemImages> FindList(Expression<Func<ItemImages, bool>> predicate)
        {
            return base.FindByWhere<ItemImages>(predicate).ToList();
        }

        public List<ItemImages> FindList(Expression<Func<ItemImages, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<ItemImages>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public ItemImages Get(Expression<Func<ItemImages, bool>> predicate)
        {
            return base.Get<ItemImages>(predicate);
        }

        public void Update(ItemImages entity)
        {
            throw new NotImplementedException();
        }
    }
}
