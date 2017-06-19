namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AmountDetail")]
    public partial class AmountDetail
    {
        [StringLength(50)]
        public string Id { get; set; }

        public decimal? Amount { get; set; }

        [StringLength(50)]
        public string AmountSourceId { get; set; }

        [StringLength(50)]
        public string ObjectId { get; set; }

        public DateTime? AmountDate { get; set; }

        [StringLength(50)]
        public string VipCurrentLevelId { get; set; }

        [StringLength(50)]
        public string VipAfterLevelId { get; set; }

        [StringLength(50)]
        public string UnitId { get; set; }

        [StringLength(50)]
        public string VipId { get; set; }
        
    }
}
