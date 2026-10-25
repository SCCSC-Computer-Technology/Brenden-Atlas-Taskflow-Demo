using Microsoft.AspNetCore.Mvc;
using TaskManager.Data;

namespace TaskManager.Controllers
{
    public class TasksController : Controller
    {

        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }

        public IActionResult SettingLocation()
        {
            return View();
        }

        //Create page

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Edit
        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskModel task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }
            _context.Tasks.Update(task);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Delete
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
