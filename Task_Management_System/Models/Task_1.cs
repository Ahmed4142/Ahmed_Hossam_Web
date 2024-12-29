using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Management_System.Models
{
    public class Task_1
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Title { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        //(Pending, In Progress, Completed)
        public string Priority { get; set; }
        //(Low, Medium, High)
        public DateTime Deadline { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        [ForeignKey("TeamMember")]
        public int TeamMemberId { get; set; }
        
        public Project Project { get; set; }
        public TeamMember TeamMember { get; set; }

    }
}
