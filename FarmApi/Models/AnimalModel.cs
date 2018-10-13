using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmApi.Models
{
    public class AnimalModel
    {
        [Key]
        public int AnimalId { get; set; }
        public string AnimalNameOrTag { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateAcquired { get; set; }
        public string AnimalType { get; set; }
        public string Breed { get; set; }

        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}