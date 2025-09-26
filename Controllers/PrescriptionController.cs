using Microsoft.AspNetCore.Mvc;
using PrescriptionApp.Models;   
using System.Linq;

namespace PrescriptionApp.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly PrescriptionContext _context;

        public PrescriptionController(PrescriptionContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            var prescriptions = _context.Prescriptions.ToList();
            return View(prescriptions);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(PrescriptionApp.Models.Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                prescription.RequestTime = DateTime.Now; 
                _context.Prescriptions.Add(prescription);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(prescription);
        }

        
        public IActionResult Edit(int id)
        {
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.PrescriptionId == id);
            if (prescription == null) return NotFound();

            return View(prescription);
        }

        
        [HttpPost]
        public IActionResult Edit(PrescriptionApp.Models.Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Prescriptions.Update(prescription);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(prescription);
        }

        
        public IActionResult Delete(int id)
        {
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.PrescriptionId == id);
            if (prescription == null) return NotFound();

            return View(prescription);
        }

        
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var prescription = _context.Prescriptions.FirstOrDefault(p => p.PrescriptionId == id);
            if (prescription == null) return NotFound();

            _context.Prescriptions.Remove(prescription);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
