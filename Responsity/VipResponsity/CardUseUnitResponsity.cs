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
    public class CardUseUnitResponsity : BaseService, ICardUseUnitResponsity
    {
        public CardUseUnitResponsity(BuinessDBContext dbContext) : base(dbContext)
        {

        }

        public void Add(CardUseUnit entity)
        {
            base.Add(entity);
        }

        public void Delete(CardUseUnit entity)
        {
            base.Delete(entity);
        }

        public List<Unit> FindByCardTypeId(string Id)
        {
            string sql = string.Format(@"SELECT u.* FROM CardUseUnit AS cuu
                                        INNER JOIN SysCardType AS sct ON cuu.CardTypeId = sct.Id
                                        INNER JOIN Unit AS u ON  u.Id = cuu.UnitId
                                        WHERE sct.Id = '{0}'", Id);
            return base.QueryBySql<Unit>(sql);
        }



        public List<CardUseUnit> FindList(Expression<Func<CardUseUnit, bool>> predicate)
        {
            return base.FindByWhere<CardUseUnit>(predicate).ToList();
        }

        public List<CardUseUnit> FindList(Expression<Func<CardUseUnit, bool>> predicate, int PageIndex, int PageSize, string OrderName, string OrderBy, out int recordCount)
        {
            return base.FindByPaged<CardUseUnit>(predicate, PageIndex, PageSize, OrderName, OrderBy, out recordCount).ToList();
        }

        public CardUseUnit Get(Expression<Func<CardUseUnit, bool>> predicate)
        {
            return base.Get<CardUseUnit>(predicate);
        }

        public void Update(CardUseUnit entity)
        {
            throw new NotImplementedException();
        }
    }
}