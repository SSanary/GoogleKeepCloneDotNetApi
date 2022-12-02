using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace GoogleKeepBackendClone.Models
{
    public class Tag
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string TagName { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [Required]
        public User User { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public ICollection<GeneralNoteInfo> Notes { get; set; }
    }
}
