namespace EFTestAWS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PageData")]
    public partial class PageData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PageData()
        {
            ButtonData = new HashSet<ButtonData>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PageID { get; set; }

        [StringLength(100)]
        public string PageTitle { get; set; }

        [StringLength(2000)]
        public string PageDescription { get; set; }

        public bool? Ending { get; set; }

        public bool? Result { get; set; }

        public bool? Victory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ButtonData> ButtonData { get; set; }
    }
}
