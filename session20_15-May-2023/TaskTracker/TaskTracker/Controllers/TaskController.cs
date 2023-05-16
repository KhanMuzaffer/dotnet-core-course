using Microsoft.AspNetCore.Mvc;
using TaskTracker.IServices;

namespace TaskTracker.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repository;

        public TaskController(ITaskRepository  repository)
        {
            this._repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
