using Microsoft.AspNetCore.Mvc;
using PrescriptionApp.Models;

namespace PrescriptionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly PrescriptionContext _context;

        public HomeController(PrescriptionContext context)
        {
            _context = context;
        }

        // Home → Show prescriptions table
        public IActionResult Index()
        {
            var prescriptions = _context.Prescriptions.ToList();
            return View(prescriptions);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
