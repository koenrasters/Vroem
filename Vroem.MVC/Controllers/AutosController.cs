using Microsoft.AspNetCore.Mvc;
using Vroem.DAL;
using Vroem.LOGIC;

namespace Vroem.MVC.Controllers
{
    public class AutosController : Controller
    {
        private readonly CarManager _car = new CarManager(new DataAccess("db"));
        // GET
        public IActionResult Index()
        {
            var car = _car.GetCars();
            return View(car);
        }
    }
}