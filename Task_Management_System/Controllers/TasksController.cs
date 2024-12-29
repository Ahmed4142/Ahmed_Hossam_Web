using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Models;

namespace Task_Management_System.Controllers
{
    public class TasksController : Controller
    {
        TaskManagementContext _context = new TaskManagementContext();
        public IActionResult Index()
        {
            var task = _context.Task.ToList();
            return View(task);
        }

        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(Task_1 task)
        {
            if (task.Status != "In Progress" && task.Status != "Completed" && task.Status != "Pending") 
            {
                ModelState.AddModelError("", "enter Status (Pending, In Progress, Completed)");
                return View(task);
            }
            if (task == null)
            {
                ModelState.AddModelError("", "Invalid data");
                return View(task);
            }
            _context.Task.Add(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            var task = _context.Task.Find(id);
            if (task == null)
            {
                ModelState.AddModelError("", "no this project");
                return View(task);
            }
            return View(task);
        }
        [HttpPost]
        public IActionResult Edit(Task_1 task)
        {
            if (task.Status != "In Progress" && task.Status != "Completed" && task.Status != "Pending")
            {
                ModelState.AddModelError("", "enter Status (Pending, In Progress, Completed)");
                return View(task);
            }
            var t = _context.Task.Find(task.Id);
            if (task == null)
            {
                ModelState.AddModelError("", "no this project");
                return View(task);
            }
            t!.TeamMember = t.TeamMember;
            t.Title = task.Title;
            t.Description = task.Description;
            t.Status = task.Status;
            t.Priority = task.Priority;
            t.Deadline = task.Deadline;
            t.ProjectId = task.ProjectId;
            t.TeamMemberId = task.TeamMemberId;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var task = _context.Task.Find(id);
            if (task == null)
            {
                ModelState.AddModelError("", "error");
                return View(task);
            }
            _context.Task.Remove(task);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
