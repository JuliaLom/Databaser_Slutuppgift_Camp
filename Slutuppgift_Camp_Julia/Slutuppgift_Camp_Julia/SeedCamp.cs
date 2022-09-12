using Slutuppgift_Camp_Julia.Data;
using Slutuppgift_Camp_Julia.Models;
using System;

namespace Slutuppgift_Camp_Julia
{
    public class SeedCamp
    {
        public static CampContext context = new CampContext();
        public void AddSeedData()
        {
            context.AddRange(
            new Camper { FirstName = "Jessica", LastName = "Vo", Age = 10, Phone = "070-333 11 22" },
            new Camper { FirstName = "Taiyo", LastName = "Loman", Age = 6, Phone = "070-123 45 67" },
            new Camper { FirstName = "Paul", LastName = "Simon", Age = 11, Phone = "070-444 55 66" },
            new Camper { FirstName = "Jimi", LastName = "Hendrix", Age = 10, Phone = "070-111 11 11" },
            new Camper { FirstName = "Shin", LastName = "Chul", Age = 8, Phone = "070-489 48 48" },
            new Camper { FirstName = "David", LastName = "Bowie", Age = 12, Phone = "070-999 99 99" },
            new Camper { FirstName = "Freddy", LastName = "Mercury", Age = 10, Phone = "070-333 11 22" },
            new Camper { FirstName = "David", LastName = "Grohl", Age = 15, Phone = "070-666 88 12" },
            new Camper { FirstName = "Taylor", LastName = "Hawkins", Age = 11, Phone = "070-165 48 54" },
            new Camper { FirstName = "Sten", LastName = "Sture", Age = 10, Phone = "070-338 11 23" },
            new Camper { FirstName = "Shaun", LastName = "White", Age = 8, Phone = "070-185 16 35" },
            new Camper { FirstName = "Fabien", LastName = "Gunn", Age = 8, Phone = "070-841 45 46" },
            new Camper { FirstName = "Ronnie", LastName = "Dio", Age = 12, Phone = "070-489 48 41" },
            new Camper { FirstName = "Nina", LastName = "Simone", Age = 15, Phone = "070-645 84 61" },
            new Camper { FirstName = "Aretha", LastName = "Franklin", Age = 14, Phone = "070-948 64 32" },
            new Camper { FirstName = "Diana", LastName = "Ross", Age = 9, Phone = "070-645 78 82" },
            new Camper { FirstName = "Mary", LastName = "Wilson", Age = 9, Phone = "070-645 61 32" },
            new Camper { FirstName = "Taylor", LastName = "Hawkins", Age = 8, Phone = "070-165 48 54" },
            new Councelor { FirstName = "Johann", LastName = "Bach", Address = "Music Street 2", Phone = "070-465 64 84" },
            new Councelor { FirstName = "Ludwig", LastName = "van Beethoven", Address = "Music Street 3", Phone = "070-465 31 31" },
            new Councelor { FirstName = "Frederic", LastName = "Chopin", Address = "Music Street 4", Phone = "070-555 16 34" },
            new Councelor { FirstName = "Wolfgang", LastName = "Mozart", Address = "Music Street 5", Phone = "070-645 61 48" },
            new Councelor { FirstName = "Claude", LastName = "Debussy", Address = "Music Street 6", Phone = "070-645 12 85" },
            new Cabin { Color = "Blue" },
            new Cabin { Color = "Red" },
            new Cabin { Color = "Yellow" },
            new Cabin { Color = "Green" },
            new Cabin { Color = "Pink" },
            new NextOfKin { FirstName = "Edwin", LastName = "Cramer", Phone = "070-156 89 15", Email = "e.cramer@gmail.com" },
            new NextOfKin { FirstName = "Creed", LastName = "Taylor", Phone = "070-654 51 55", Email = "c.taylor@gmail.com" },
            new NextOfKin { FirstName = "John", LastName = "Pike", Phone = "070-654 94 99", Email = "j.pike@gmail.com" },
            new NextOfKin { FirstName = "Juliet", LastName = "Wilhelmsson", Phone = "070-654 46 25", Email = "j.wil@gmail.com" }
            );
            context.SaveChanges();
        }
        public void SeedCamperStay()
        {
            DateTime now = DateTime.Now;
            DateTime date2 = new DateTime(2022, 3, 31);
            context.AddRange(

                new CamperStay { CamperID = 1, CabinID = 5, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 2, CabinID = 1, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 3, CabinID = 1, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 4, CabinID = 1, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 5, CabinID = 1, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 6, CabinID = 2, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 7, CabinID = 2, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 8, CabinID = 2, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 9, CabinID = 2, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 10, CabinID = 3, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 11, CabinID = 3, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 12, CabinID = 3, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 13, CabinID = 3, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 14, CabinID = 4, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 15, CabinID = 4, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 16, CabinID = 4, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 17, CabinID = 4, DateStart = now, DateEnd = date2 },
                new CamperStay { CamperID = 18, CabinID = 5, DateStart = now, DateEnd = date2 }
               
                );
            context.SaveChanges();
        }
        public void SeedCouncelorStay()
        {
            DateTime now = DateTime.Now;
            DateTime date2 = new DateTime(2022, 3, 31);
            context.AddRange(
                new CouncelorStay { CouncelorID = 1, CabinID = 1, DateStart = now, DateEnd = date2 },
                new CouncelorStay { CouncelorID = 2, CabinID = 2, DateStart = now, DateEnd = date2 },
                new CouncelorStay { CouncelorID = 3, CabinID = 3, DateStart = now, DateEnd = date2 },
                new CouncelorStay { CouncelorID = 4, CabinID = 4, DateStart = now, DateEnd = date2 },
                new CouncelorStay { CouncelorID = 5, CabinID = 5, DateStart = now, DateEnd = date2 }
                );
            context.SaveChanges();
        }
        public void SeedNextOfKinVisits()
        {
            DateTime now = DateTime.Now;
            DateTime date2 = new DateTime(2022, 3, 25);
            context.AddRange(
                new NextOfKinVisit { CamperID = 2, NextOfKinID = 1, DateStart = now, DateEnd = date2 },
                new NextOfKinVisit { CamperID = 3, NextOfKinID = 2, DateStart = now, DateEnd = date2 },
                new NextOfKinVisit { CamperID = 5, NextOfKinID = 3, DateStart = now, DateEnd = date2 },
                new NextOfKinVisit { CamperID = 8, NextOfKinID = 4, DateStart = now, DateEnd = date2 });
            context.SaveChanges();
        }
        
    }
}
