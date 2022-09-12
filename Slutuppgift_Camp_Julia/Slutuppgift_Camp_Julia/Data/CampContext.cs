using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Slutuppgift_Camp_Julia.Models;

namespace Slutuppgift_Camp_Julia.Data
{
    public class CampContext : DbContext
    {
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Camper> Campers { get; set; }
        public DbSet<Councelor> Councelors { get; set; }
        public DbSet<CamperStay> CamperStay { get; set; }
        public DbSet<CouncelorStay> CouncelorStay { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<NextOfKinVisit> NextOfKinVisit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-46V8V26\\SQLEXPRESS;Database=CampJulia2;Trusted_Connection=True;");
        }

    }
}
