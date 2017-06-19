namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysDate")]
    public partial class SysDate
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? the_date { get; set; }

        [StringLength(15)]
        public string the_day { get; set; }

        [StringLength(15)]
        public string the_month { get; set; }

        public short? the_year { get; set; }

        public short? day_of_month { get; set; }

        public short? week_of_year { get; set; }

        public short? month_of_year { get; set; }

        [StringLength(2)]
        public string quarter { get; set; }

        [StringLength(20)]
        public string fiscal_period { get; set; }
    }
}
