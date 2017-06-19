namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CouponCategory")]
    public partial class CouponCategory
    {
        [StringLength(50)]
        public string CouponCategoryId { get; set; }

        [StringLength(50)]
        public string CouponName { get; set; }

        public int? CouponMoney { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        [StringLength(50)]
        public string CouponCodeFirst { get; set; }

        [StringLength(50)]
        public string CouponCodeLast { get; set; }

        public int? CouponCount { get; set; }

        public int? IsNotLimit { get; set; }

        public int? HaveCouponCount { get; set; }

        [StringLength(50)]
        public string CouponImages { get; set; }

        public int? IsGIve { get; set; }

        public int HasSend { get; set; }

        public int LaveCount { get; set; }
    }
}
