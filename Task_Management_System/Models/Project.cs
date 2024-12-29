using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 
        public List<Task_1> Tasks {  get; set; }
    }
}
