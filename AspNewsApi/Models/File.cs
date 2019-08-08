namespace AspNewsApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class File
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Uri { get; set; }

        [Required]
        [StringLength(255)]
        public string Mime { get; set; }

        public long Size { get; set; }

        [Required]
        [StringLength(255)]
        public string Type { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime UpdatedAt { get; set; }

        public int UserId { get; set; }

        public int? MatterId { get; set; }

        public int? PhotoId { get; set; }

        public int? VideoId { get; set; }

        public int? AudioId { get; set; }

        public virtual Audio Audio { get; set; }

        public virtual Matter Matter { get; set; }

        public virtual Photo Photo { get; set; }

        public virtual User User { get; set; }

        public virtual Video Video { get; set; }
    }
}
