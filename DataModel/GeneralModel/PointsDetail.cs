namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PointsDetail")]
    public partial class PointsDetail
    {
        [StringLength(50)]
        public string Id { get; set; }

        public int? Points { get; set; }

        [StringLength(50)]
        public string PointsSourceId { get; set; }

        [StringLength(50)]
        public string ObjectId { get; set; }

        public DateTime? PointsDate { get; set; }

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
