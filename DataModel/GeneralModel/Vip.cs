namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vip")]
    public partial class Vip
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string VipName { get; set; }

        [StringLength(50)]
        public string VipPhone { get; set; }

        [StringLength(50)]
        public string VipEmail { get; set; }

        [StringLength(50)]
        public string VipOnLineId { get; set; }

        public int? VipOnLineCategory { get; set; }

        public int? VipSourceId { get; set; }

        public int? VipPoints { get; set; }

        public decimal? VipAmount { get; set; }

        [StringLength(50)]
        public string VipCardLevel { get; set; }
    }
}
