using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Management_System.Models;

namespace Task_Management_System.Controllers
{
    public class TeamMembersController : Controller
    {
        TaskManagementContext _context = new TaskManagementContext();
        public IActionResult Details()
        {
            var teamMember = _context.Task.Include(t=> t.TeamMember).ToList();
            return View(teamMember);
        }

    }
}
