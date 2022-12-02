using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace GoogleKeepBackendClone.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        public ICollection<Note>? Notes { get; set; }
        public ICollection<Tag>? Tags { get; set; }
        public ICollection<Reminder>? Reminders { get; set; }
    }
}
