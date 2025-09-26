using System;
using System.ComponentModel.DataAnnotations;

namespace PrescriptionApp.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        [Required(ErrorMessage = "Medication Name is required")]
        [StringLength(100)]
        public string MedicationName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fill Status is required")]
        public string FillStatus { get; set; } = string.Empty;

        [Range(0.01, 1000.00, ErrorMessage = "Cost must be between 0.01 and 1000")]
        public double Cost { get; set; }

        public DateTime RequestTime { get; set; } = DateTime.Now;
    }
}
