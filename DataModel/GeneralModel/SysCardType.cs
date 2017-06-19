namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysCardType")]
    public partial class SysCardType
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string SysCardName { get; set; }

        public int? SysCardLevel { get; set; }

        public int? IsOnLine { get; set; }

        [StringLength(50)]
        public string SysCardTypeIMages { get; set; }

        public int? SysCardTypeStatus { get; set; }

        public int? IsSaleUpgrade { get; set; }

        public decimal? SaleMinMoney { get; set; }

        public int? IsFirstRechargeUpgrade { get; set; }

        public decimal? RechargeMinMoney { get; set; }

        public int? IsSaleTotalUpgrade { get; set; }

        public decimal? SaleTotalUpgradeMinMOney { get; set; }

        public decimal? DisCount { get; set; }
    }
}
