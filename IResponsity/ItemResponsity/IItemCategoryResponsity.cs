using DataCommTools;
using DataModel.GeneralModel;
using IOCAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
   // [Log]
    public interface ICategoryResponsity
    {
        void Add(Category pEntity);

        List<Category> FindList();

        List<Category> FindList(string nodeName, string OrderName, string Order);

        Category Get(Expression<Func<Category, bool>> predicate);

        void Delete(Category entity);

        //List<Category> FindList(Category entity);
    }
}
