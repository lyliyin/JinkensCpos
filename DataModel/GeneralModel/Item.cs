namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [StringLength(50)]
        public string Id { get; set; }

        public string ItemName { get; set; }

        [StringLength(50)]
        public string ItemCode { get; set; }

        public string ItemDescription { get; set; }

        public int? ItemStatus { get; set; }

        public int? SourcesId { get; set; }

        [StringLength(50)]
        public string BrandId { get; set; }

        [StringLength(50)]
        public string CategoryId { get; set; }

        public int? IsGift { get; set; }

        public int? IsUseCoupon { get; set; }
    }
}
