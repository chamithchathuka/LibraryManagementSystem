namespace Library_Management_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public int id { get; set; }

        [Column("category")]
        [StringLength(50)]
        public string category1 { get; set; }

        [StringLength(50)]
        public string shelf { get; set; }
    }
}
