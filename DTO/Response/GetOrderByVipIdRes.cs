using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GetOrderByVipIdRes
    {
        public string OrderNo { get; set; }
        public decimal UsePoint { get; set; }
        public decimal UseAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ActualAmount { get; set; }
        public string UnitName { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int CouponMoney { get; set; }
        public string Discount { get; set; }
    }


}
