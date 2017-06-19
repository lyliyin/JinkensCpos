namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CardUseUnit")]
    public partial class CardUseUnit
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string CardTypeId { get; set; }

        [StringLength(50)]
        public string UnitId { get; set; }
    }
}
