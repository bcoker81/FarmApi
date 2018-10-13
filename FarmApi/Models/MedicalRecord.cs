using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmApi.Models
{
    public class MedicalRecord
    {
        [Key]
        public int MedicalId { get; set; }
        public string VaccinationDescription { get; set; }
        public DateTime VaccinationDate { get; set; }
        public string Dosage { get; set; }
        public int Fk_Animal_Id { get; set; }

        [ForeignKey("Fk_Animal_Id")]
        public AnimalModel Animal { get; set; }
    }
}