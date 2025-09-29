using Microsoft.AspNetCore.Mvc;
using PrescriptionApp.Models;

// Alias to fix the naming conflict between namespace and model class
using PrescriptionModel = PrescriptionApp.Models.Prescription;

namespace PrescriptionApp.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly PrescriptionContext _context;

        public PrescriptionController(PrescriptionContext context)
        {
            _context = context;
        }

        // Show all prescriptions
        public IActionResult Index()
        {
            var prescriptions = _context.Prescriptions.ToList();
            return View(prescriptions);
        }

        // GET: Create prescription
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create prescription
        [HttpPost]
        public IActionResult Create(PrescriptionModel prescription)
        {
            if (ModelState.IsValid)
            {
                prescription.RequestTime = DateTime.Now; // Set current time
                _context.Prescriptions.Add(prescription);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prescription);
        }

        // GET: Edit prescription
        public IActionResult Edit(int id)
        {
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.PrescriptionId == id);
            if (prescription == null)
            {
                return NotFound();
            }
            return View(prescription);
        }

        // POST: Edit prescription
        [HttpPost]
        public IActionResult Edit(PrescriptionModel prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Prescriptions.Update(prescription);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prescription);
        }

        // GET: Delete confirmation
        public IActionResult Delete(int id)
        {
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.PrescriptionId == id);
            if (prescription == null)
            {
                return NotFound();
            }
            return View(prescription);
        }

        // POST: Delete prescription
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.PrescriptionId == id);
            if (prescription != null)
            {
                _context.Prescriptions.Remove(prescription);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}


