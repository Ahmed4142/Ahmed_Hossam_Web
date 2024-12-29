using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class TaskManagementContext : DbContext
    {
        public DbSet<Task_1> Task { get; set; }
        public DbSet<TeamMember> TeamMember { get; set; }
        public DbSet<Project> Project { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=FS-COMLAB3-PC24;Initial Catalog=TaskManagement;User ID=sa;Password=FIATS@2024;Encrypt=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
