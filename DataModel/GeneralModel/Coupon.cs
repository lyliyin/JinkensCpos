namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Coupon")]
    public partial class Coupon
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string CouponCategoryId { get; set; }

        [StringLength(50)]
        public string CouponCode { get; set; }
    }
}
