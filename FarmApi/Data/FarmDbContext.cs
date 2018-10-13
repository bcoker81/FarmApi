using FarmApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FarmApi.Data
{
    public class FarmDbContext : DbContext
    {
        public FarmDbContext() : base("name=FarmDb")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<AnimalModel> Animals { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
    }
}