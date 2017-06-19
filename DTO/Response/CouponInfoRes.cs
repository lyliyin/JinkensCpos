using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CouponInfoRes
    {
        public string CouponCategoryId { get; set; }

        public string CouponName { get; set; }

        public int? CouponMoney { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string CouponCodeFirst { get; set; }

        public string CouponCodeLast { get; set; }

        public int? CouponCount { get; set; }

        public int? IsNotLimit { get; set; }

        public int? HaveCouponCount { get; set; }

        public string CouponImages { get; set; }

        public int? IsGIve { get; set; }

        public int HasSend { get; set; }

        public int IsOverDue { get; set; }
        public int LaveCount { get; set; }
    }
}
