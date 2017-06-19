namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderRewardRule")]
    public partial class OrderRewardRule
    {
        [StringLength(50)]
        public string Id { get; set; }

        public int? RewardCategory { get; set; }

        public int? RewardFunction { get; set; }

        public int? RewardCondition { get; set; }

        [StringLength(50)]
        public string RewardValue { get; set; }
    }
}
