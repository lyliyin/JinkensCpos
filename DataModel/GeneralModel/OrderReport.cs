namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderReport")]
    public partial class OrderReport
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string UnitId { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }

        [StringLength(50)]
        public string CategoryId { get; set; }

        [StringLength(50)]
        public string BrandId { get; set; }

        public int? SourcesId { get; set; }

        public decimal? ActualAmount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        [StringLength(50)]
        public string PayMethod { get; set; }
    }
}
