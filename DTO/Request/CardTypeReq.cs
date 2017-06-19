using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CardTypeReq
    {
        /// <summary>
        /// 
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String SysCardName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? SysCardLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? IsOnLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String SysCardTypeIMages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? SysCardTypeStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? IsSaleUpgrade { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? SaleMinMoney { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? IsFirstRechargeUpgrade { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? RechargeMinMoney { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? IsSaleTotalUpgrade { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? SaleTotalUpgradeMinMOney { get; set; }

        public decimal DisCount { get; set; }

        public List<CouponCategorys> couponcategorys { get; set; }
        public List<UnitInfo> units { get; set; }
        public CardTypeReq()
        {
            couponcategorys = new List<CouponCategorys>();
            units = new List<UnitInfo>();
        }
    }

    //门店
    public class UnitInfo
    {
        public string Id { get; set; }

        public string UnitName { get; set; }

        public string UnitCode { get; set; }

        public string UserName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Pid { get; set; }
    }
    public class CouponCategorys
    {

        public string CouponCategoryId { get; set; }


        public string CouponName { get; set; }

        public int? CouponMoney { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }


        public string CouponCodeFirst { get; set; }


        public string CouponCodeLast { get; set; }

        public int? CouponCount { get; set; }

        public int? IsNotLimit { get; set; }

        public int? HaveCouponCount { get; set; }


        public string CouponImages { get; set; }

        public int? IsGIve { get; set; }
    }
}
