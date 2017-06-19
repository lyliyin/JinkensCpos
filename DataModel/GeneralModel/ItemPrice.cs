namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ItemPrice")]
    public partial class ItemPrice
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string ItemId { get; set; }

        public decimal? Price { get; set; }

        public int? StoreCount { get; set; }
    }
}
