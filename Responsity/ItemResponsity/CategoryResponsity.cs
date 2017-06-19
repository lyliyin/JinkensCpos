using IResponsity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Linq.Expressions;
using DataModel.GeneralModel;
using System.Linq.Dynamic;

namespace Responsity
{
    public class CategoryResponsity : BaseService, ICategoryResponsity
    {
        public CategoryResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(Category pEntity)
        {
            base.Add(pEntity);
        }

        public void Delete(Category entity)
        {
            base.Delete(entity);
        }

        public List<Category> FindList()
        {
            Expression<Func<Item, Category, bool>> innerKeySelector = (t, m) => t.CategoryId == m.Id;
            return base.FindAll<Category>().ToList();
        }

        public List<Category> FindList(string nodeName, string OrderName, string Order)
        {

            if (String.IsNullOrWhiteSpace(OrderName))
            {
                OrderName = "CategoryName";
                Order = "asc ";
            }
            string sql = string.Format(@"WITH cteTree
                                        AS(SELECT *
                                              FROM Category
                                              WHERE CategoryName = '{0}'--第一个查询作为递归的基点(锚点)
                                            UNION ALL
                                            SELECT Category.* --第二个查询作为递归成员， 下属成员的结果为空时，此递归结束。
                                              FROM
                                                   cteTree INNER JOIN Category ON cteTree.Id = Category.Pid)
                                        SELECT * FROM cteTree ORDER BY {1} {2} ", nodeName, OrderName, Order);
            return base.QueryBySql<Category>(sql, null);
        }

        public Category Get(Expression<Func<Category, bool>> predicate)
        {
            return base.Get<Category>(predicate);
        }
    }
}
