using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoogleKeepBackendClone.Models
{
    public class Note
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public bool IsAchived { get; set; }
        [Required]
        public DateTime LastChangeTime { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public User User { get; set; }
        [Required]
        [StringLength(200)]
        public string Context { get; set; }
        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
