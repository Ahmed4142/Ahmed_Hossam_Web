using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Management_System.Models;

namespace Task_Management_System.Controllers
{
    public class ProjectsController : Controller
    {
        TaskManagementContext _context = new TaskManagementContext();
        public IActionResult Index()
        {
            var project = _context.Project.ToList();
            return View(project);
        }
        public IActionResult Details()
        {
            var project = _context.Task.Include(p => p.Project).
                Include(t=> t.TeamMember).ToList();
            return View(project);
        }

        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(Project project)
        {
            if (project == null)
            {
                ModelState.AddModelError("", "Invalid data");
                return View(project);
            }
            _context.Project.Add(project);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var project = _context.Project.Find(id);
            if (project == null)
            {
                ModelState.AddModelError("", "no this project");
                return View(project);
            }
            return View(project);
        }
        [HttpPost]
        public IActionResult Edit(Project project)
        {
            var p = _context.Project.Find(project.Id);
            if (project == null)
            {
                ModelState.AddModelError("", "no this project");
                return View(project);
            }
            
            
            p!.Tasks = p.Tasks;
            p.Name = project.Name;
            p.Description = project.Description;
            p.StartDate = project.StartDate;
            p.EndDate = project.EndDate;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id) 
        {
            var project = _context.Project.Find(id);
            if(project == null)
            {
                ModelState.AddModelError("", "error");
                return View(project);
            }
            _context.Project.Remove(project);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
