namespace DataModel.GeneralModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ItemImages
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string ItemId { get; set; }

        [StringLength(300)]
        public string ImagesUrl { get; set; }
    }
}
