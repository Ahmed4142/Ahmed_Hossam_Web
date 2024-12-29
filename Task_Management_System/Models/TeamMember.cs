using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Name { get; set; }
        [Required,StringLength(100)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Role { get; set; }
        public List<Task_1> Tasks { get; set; }
    }
}
