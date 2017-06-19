using DataModel.GeneralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IResponsity
{
    public interface ICardUseUnitResponsity
    {
        void Add(CardUseUnit entity);

        CardUseUnit Get(Expression<Func<CardUseUnit, bool>> predicate);

        List<CardUseUnit> FindList(Expression<Func<CardUseUnit, bool>> predicate);

        List<CardUseUnit> FindList(Expression<Func<CardUseUnit, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount);

        void Update(CardUseUnit entity);

        void Delete(CardUseUnit entity);

        List<Unit> FindByCardTypeId(string Id);
    }
}
