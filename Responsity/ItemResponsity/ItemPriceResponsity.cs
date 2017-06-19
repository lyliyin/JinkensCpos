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
    public class ItemPriceResponsity : BaseService,IItemPriceResponsity
    {
        public ItemPriceResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(ItemPrice entity)
        {
            base.Add(entity);
        }

        public void Delete(ItemPrice entity)
        {
            base.Delete(entity);
        }

        public List<ItemPrice> FindList(Expression<Func<ItemPrice, bool>> predicate)
        {
            return base.FindByWhere<ItemPrice>(predicate).ToList();
        }

        public List<ItemPrice> FindList(Expression<Func<ItemPrice, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<ItemPrice>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public ItemPrice Get(Expression<Func<ItemPrice, bool>> predicate)
        {
            return base.Get<ItemPrice>(predicate);
        }

        public void Update(ItemPrice entity)
        {
            throw new NotImplementedException();
        }


        public void ExcuteSqls(string sql)
        {
            base.ExcuteSql(sql);
        }
    }
}

