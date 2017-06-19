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
    public class ItemResponsity : BaseService, IItemResponsity
    {
        public ItemResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(Item entity)
        {
            base.Add(entity);
        }

        public void Delete(Item entity)
        {
            base.Delete(entity);
        }

        public List<Item> FindList(Expression<Func<Item, bool>> predicate)
        {
            return base.FindByWhere<Item>(predicate).ToList();
        }

        public List<Item> FindList(Expression<Func<Item, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<Item>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public List<T> FindList<T>(string BrandId, string CategoryId, string ItemCode, string ItemName, int PageIndex, int PageSize, string OrderName, string OrderBy, out int RecordCount) where T : class
        {
            string sql = @"SELECT * FROM ( SELECT i.ItemName,i.ItemCode,b.BrandName,c.CategoryName,ip.Price,ip.StoreCount,s.SkuName,ROW_NUMBER () OVER (ORDER BY Price desc) AS RowId
                            FROM Item AS i
                            INNER JOIN Category AS c ON I.CategoryId = C.Id
                            INNER JOIN Brand AS b ON B.Id = I.BrandId
                            INNER JOIN ItemPrice AS ip ON IP.ItemId = I.Id
                            INNER JOIN PriceSku AS ps ON PS.PriceId = IP.Id
                            INNER JOIN Sku AS s ON S.Id = PS.SkuId
                            WHERE 1 = 1";

            if (!String.IsNullOrWhiteSpace(BrandId))
            {
                sql += string.Format(" b.Id='{0}'", BrandId);
            }

            if (!String.IsNullOrWhiteSpace(CategoryId))
            {
                sql += string.Format(" c.Id='{0}'", CategoryId);
            }

            if (!String.IsNullOrWhiteSpace(ItemCode))
            {
                sql += string.Format(" i.ItemCode='{0}'", ItemCode);
            }

            if (!String.IsNullOrWhiteSpace(ItemName))
            {
                sql += string.Format(" i.ItemName='{0}'", ItemName);
            }
            sql += " ) as t";

            RecordCount = QueryBySql<T>(sql).Count();

            sql += string.Format(" WHERE t.RowId>{0} and t.RowId<={1}", PageIndex * PageSize, (PageIndex + 1) * PageSize);

            return QueryBySql<T>(sql).ToList();
        }

        public Item Get(Expression<Func<Item, bool>> predicate)
        {
            return base.Get<Item>(predicate);
        }

        public T GetItemBySql<T>(string sql) where T : class
        {
            return QueryBySql<T>(sql).FirstOrDefault();
        }

        public void Update(Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
