namespace EFTestAWS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ButtonData")]
    public partial class ButtonData
    {
        public int ID { get; set; }

        public int? ButtonID { get; set; }

        [StringLength(500)]
        public string ButtonDescription { get; set; }

        public int? ButtonDestinationPage { get; set; }

        public int? PageData { get; set; }

        public virtual PageData PageData1 { get; set; }
    }
}
