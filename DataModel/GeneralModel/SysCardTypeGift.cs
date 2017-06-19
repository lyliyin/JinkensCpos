namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysCardTypeGift")]
    public partial class SysCardTypeGift
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string SysCardTypeId { get; set; }

        [StringLength(50)]
        public string CouponCategoryId { get; set; }
    }
}
