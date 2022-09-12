using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slutuppgift_Camp_Julia.Models;
using Slutuppgift_Camp_Julia.Data;

namespace Slutuppgift_Camp_Julia

{
    class Methods
    {
        public static CampContext context = new CampContext();

        
        public void AddNewCamper()
        {
            Console.WriteLine("Enter First Name:");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Phone:");
            string phone = Console.ReadLine();
            var camper = new Camper { FirstName = firstname, LastName = lastname, Age = age, Phone = phone };
            context.Campers.Add(camper);
            context.SaveChanges();
            Console.WriteLine($"Camper was added: Name: {firstname} {lastname} Age: {age} Phone: {phone}");
        }/* Adds a new camper to the database */
        
        public void AddCamperToStay()
        {
            Console.WriteLine("Please enter the last name of the camper:");
            string name = Console.ReadLine();
            var camper = context.Campers.Where(c => c.LastName == name).FirstOrDefault();
            int camperID = camper.CamperID;

            Console.WriteLine("Please enter the color of the cabin:");
            string color = Console.ReadLine();
            var cabin = context.Cabins.Where(cab => cab.Color == color).FirstOrDefault();
            int cabinID = cabin.CabinID;

            DateTime now = DateTime.Now;
            Console.WriteLine("The Start Date of the Stay will be Today, please enter the End Date of the Stay (mm/dd/yyyy):");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());

            var campersCount = context.CamperStay.Where(c => c.CamperID == camperID && c.DateEnd >= now).ToList();
            if (campersCount.Count > 0)
            {
                Console.WriteLine("Error! This camper is already assigned to a different cabin. Please try later.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            var councelorStay = context.CouncelorStay.Where(c => c.CabinID == cabinID && c.DateEnd >= now).ToList();
            if (councelorStay.Count == 0)
            {
                Console.WriteLine("Warning! There is no councelor in this cabin. Press any key to try a different cabin.");
                Console.ReadKey();
                AddCamperToStay();
            }

            var campersInCabin = context.CamperStay.Where(c => c.CabinID == cabinID && c.DateEnd >= now).ToList();

            if (campersInCabin.Count >= 4)
            {
                Console.WriteLine("Error! The max capacity of a cabin is 4 campers. Please choose a different cabin.");
                Console.ReadKey();
                AddCamperToStay();
            }
            else
            {
                var camperStay = new CamperStay { CamperID = camperID, CabinID = cabinID, DateStart = now, DateEnd = endDate };
                context.CamperStay.Add(camperStay);
                context.SaveChanges();
            }

        } /*Add a camper to a cabin*/
        public void UpdateCamper()
        {
            Console.WriteLine("Enter the first name of the camper you wish to update:");
            string name = Console.ReadLine();
            var camper = context.Campers.Where(c => c.FirstName == name).FirstOrDefault();
            if (camper is Camper)
            {
                Console.WriteLine("Enter new name:");
                string camperNewName = Console.ReadLine();
                camper.FirstName = camperNewName;
                context.SaveChanges();
                Console.WriteLine("Camper was updated.");
            }
            else
            {
                Console.WriteLine("No camper was found.");
            }
        }/* Updates info about an existing camper */

        public void DeleteCamper()
        {
            Console.WriteLine("Enter First Name:");
            string name = Console.ReadLine();
            var camper = context.Campers.Where(c => c.FirstName == name).FirstOrDefault();
            int id = camper.CamperID;
            var camperStay = context.CamperStay.Where(c => c.CamperID == id).FirstOrDefault();
            if (camperStay is CamperStay)
            {
                Console.WriteLine("This camper could not be deleted.");
            }
            else
            {
                context.Remove(camper);
                context.SaveChanges();
                Console.WriteLine("Camper deleted.");
            }
        }/* Deletes a camper from the database */
        
        public void SearchCampersByCabin()
        {
            Console.WriteLine("Please enter the color of the Cabin you wish to see:");
            string color = Console.ReadLine();
            var cabin = context.Cabins.Where(c => c.Color == color).FirstOrDefault();
            int id = cabin.CabinID;
            DateTime now = DateTime.Now;
            var query = from c in context.Campers
                        join cs in context.CamperStay on c.CamperID equals cs.CamperID
                        join ca in context.Cabins on cs.CabinID equals ca.CabinID

                        join nv in context.NextOfKinVisit on c.CamperID equals nv.CamperID
                        join n in context.NextOfKins on nv.NextOfKinID equals n.NextOfKinID

                        where ca.CabinID == id
                        where cs.DateEnd >= now
                        select new
                        {
                            cFirstName = c.FirstName,
                            cLastName = c.LastName,
                            nFirstName = n.FirstName,
                            nLastName = n.LastName,
                            ca.Color,
                            cs.DateStart,
                            cs.DateEnd
                        };
            

            var councelorStay = context.CouncelorStay.Where(cs => cs.CabinID == id && cs.DateEnd >= now).ToList();

            if (councelorStay.Count == 0)
            {
                Console.WriteLine("Warning! There is no councelor in this cabin.");
                Console.ReadKey();
            }
            foreach (var i in query)
            {
                Console.WriteLine($"Camper: {i.cFirstName} {i.cLastName} Cabin: {i.Color} - {i.DateStart} - {i.DateEnd} NextOfKin: {i.nFirstName} {i.nLastName}");
            }

        }/* Finds all campers in a specific cabin */

        public void SearchCampersByCouncelor()
        {
            Console.WriteLine("Please enter the Last Name of the Councelor:");
            string name = Console.ReadLine();
            var councelor = context.Councelors.Where(c => c.LastName == name).FirstOrDefault();
            int id = councelor.CouncelorID;
            DateTime now = DateTime.Now;


            var query = from c in context.Councelors
                        join cs in context.CouncelorStay on c.CouncelorID equals cs.CouncelorID
                        join ca in context.Cabins on cs.CabinID equals ca.CabinID

                        from cam in context.Campers
                        join nv in context.NextOfKinVisit on cam.CamperID equals nv.CamperID
                        join n in context.NextOfKins on nv.NextOfKinID equals n.NextOfKinID

                        where ca.CabinID == id
                        where cs.DateEnd >= now
                        select new
                        {
                            camFirstName = cam.FirstName,
                            camLastName = cam.LastName,
                            nFirstName = n.FirstName,
                            nLastName = n.LastName,
                            ca.Color,
                            cs.DateStart,
                            cs.DateEnd
                        };


            var councelorStay = context.CouncelorStay.Where(cs => cs.CabinID == id && cs.DateEnd >= now).ToList();

            if (councelorStay.Count == 0)
            {
                Console.WriteLine("Warning! This councelor has not been assigned to a cabin.");
                Console.ReadKey();
            }
            foreach (var i in query)
            {
                Console.WriteLine($"Camper: {i.camFirstName} {i.camLastName} Cabin: {i.Color} - {i.DateStart} - {i.DateEnd} NextOfKin: {i.nFirstName} {i.nLastName}");
            }

        }/* Finds all campers in a specific councelors care */
        public void HistoryCamperStays()
        {
            Console.WriteLine("Please enter the color of the Cabin you wish to see the history of:");
            string color = Console.ReadLine();
            var cabin = context.Cabins.Where(c => c.Color == color).FirstOrDefault();
            int id = cabin.CabinID;
            var camperStayList = context.CamperStay.Where(c => c.CabinID == id).ToList();
            //var camperStayListTest = context.Campers.Where(c => c.CamperStay == id).ToList();
            var query = from c in context.Campers
                        join cs in context.CamperStay on c.CamperID equals cs.CamperID
                        join ca in context.Cabins on cs.CabinID equals ca.CabinID
                        where ca.CabinID == id
                        select new
                        {
                            c.FirstName,
                            c.LastName,
                            ca.Color,
                            cs.DateStart,
                            cs.DateEnd
                        };
            foreach (var cs in query)
            {
                Console.WriteLine($"Camper: {cs.FirstName} {cs.LastName} Cabin: {cs.Color} Dates: {cs.DateStart} - {cs.DateEnd}");
            }
        }

        /*******************************************************************************************/

        public void AddNewCouncelor()
        {
            Console.WriteLine("Enter First Name:");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Phone:");
            string phone = Console.ReadLine();
            var councelor = new Councelor { FirstName = firstname, LastName = lastname, Address = address, Phone = phone };
            context.Councelors.Add(councelor);
            context.SaveChanges();
            Console.WriteLine($"Councelor was added: Name: {firstname} {lastname} Address: {address} Phone: {phone}");
        }/* Adds a new councelor to the database */

        public void AddCouncelorToStay()
        {

            Console.WriteLine("Please enter the last name of the Councelor:");
            string name = Console.ReadLine();
            var councelor = context.Councelors.Where(c => c.LastName == name).FirstOrDefault();
            int councelorID = councelor.CouncelorID;

            Console.WriteLine("Please enter the color of the cabin:");
            string color = Console.ReadLine();
            var cabin = context.Cabins.Where(cab => cab.Color == color).FirstOrDefault();
            int cabinID = cabin.CabinID;

            DateTime now = DateTime.Now;
            Console.WriteLine("The Start Date of the Stay will be Today, please enter the End Date of the Stay (mm/dd/yyyy):");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());

            var councelorsCount = context.CouncelorStay.Where(c => c.CouncelorID == councelorID && c.DateEnd >= now).ToList();
            if (councelorsCount.Count > 0)
            {
                Console.WriteLine("Error! This councelor is already assigned to a different cabin. Please try later.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            var councelorStayCount = context.CouncelorStay.Where(c => c.CabinID == cabinID && c.DateEnd >= endDate).ToList();
            if (councelorStayCount.Count > 0)
            {
                Console.WriteLine("Error! There is already a councelor in that cabin. Press any key to exit and try again.");
                Console.ReadKey();
                Environment.Exit(1);
            }
            else
            {
                var councelorStay = new CouncelorStay { CouncelorID = councelorID, CabinID = cabinID, DateStart = now, DateEnd = endDate };
                context.CouncelorStay.Add(councelorStay);
                context.SaveChanges();
                Console.WriteLine($"The councelor: {name} was added to the cabin: {color}.");
            }

        }/*Add a councelor to a cabin*/
        public void UpdateCouncelor()
        {
            Console.WriteLine("Enter the first name of the councelor you wish to update:");
            string name = Console.ReadLine();
            var councelor = context.Councelors.Where(c => c.FirstName == name).FirstOrDefault();
            if (councelor is Councelor)
            {
                Console.WriteLine("Enter new name:");
                string councelorNewName = Console.ReadLine();
                councelor.FirstName = councelorNewName;
                context.SaveChanges();
                Console.WriteLine("Councelor was updated.");
            }
            else
            {
                Console.WriteLine("No councelor was found.");
            }
        } /* Updates info about an existing councelor */
        
        public void DeleteCouncelor()
        {
            Console.WriteLine("Enter Last Name:");
            string name = Console.ReadLine();
            var councelor = context.Councelors.Where(c => c.LastName == name).FirstOrDefault();
            int id = councelor.CouncelorID;
            DateTime now = DateTime.Now;
            var councelorStay = context.CouncelorStay.Where(c => c.CouncelorID == id && c.DateEnd >= now).FirstOrDefault();

            if (councelorStay != null)
            {
                Console.WriteLine("Error! This Councelor could not be deleted because he/she is responsible for a cabin with children in it.");
            }
            else
            {
                context.Remove(councelor);
                context.SaveChanges();
                Console.WriteLine("The councelor was deleted.");
            }
        }/* Deletes a councelor from the database */

        /*******************************************************************************************/
       
        public void AddNewCabin()
        {
            Console.WriteLine("Enter the color of the new cabin:");
            string cabinColor = Console.ReadLine();
            context.Add(new Cabin { Color = cabinColor });
            context.SaveChanges();
            Console.WriteLine("Cabin was added.");
        } /* Adds a new cabin to the database */
        
        public void UpdateCabin()
        {
            Console.WriteLine("Enter the color of the cabin you wish to update:");
            string color = Console.ReadLine();
            var cabin = context.Cabins.Where(c => c.Color == color).FirstOrDefault();
            if (cabin is Cabin)
            {
                Console.WriteLine("Enter the new color of the cabin:");
                string cabinColor = Console.ReadLine();
                cabin.Color = cabinColor;
                context.SaveChanges();
                Console.WriteLine("Cabin was updated.");
            }
            else
            {
                Console.WriteLine("Could not find cabin.");
            }
        }/* Updates info about an existing cabin */
        
        public void DeleteCabin()
        {
            Console.WriteLine("Enter the color of the cabin:");
            string color = Console.ReadLine();
            var cabin = context.Cabins.Where(c => c.Color == color).FirstOrDefault();
            int id = cabin.CabinID;
            var cabinId = context.Cabins.Where(c => c.CabinID == id).FirstOrDefault();
            DateTime now = DateTime.Now;
            var camperStay = context.CamperStay.Where(c => c.CabinID == id && c.DateEnd >= now).FirstOrDefault();
            if (camperStay != null)
            {
                Console.WriteLine("Error! The cabin cannot be removed because there are people staying in it.");
            }
            else
            {
                context.Remove(cabin);
                context.SaveChanges();
                Console.WriteLine("The cabin was deleted.");
            }
        }/* Deletes a cabin from the database */

        

        /*******************************************************************************************/

        public void AddNewNextOfKin()
        {
            Console.WriteLine("Enter First Name:");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter Phone:");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();
            var nextOfKin = new NextOfKin { FirstName = firstname, LastName = lastname, Phone = phone, Email = email };
            context.NextOfKins.Add(nextOfKin);
            context.SaveChanges();
            Console.WriteLine($"Next of Kin added: Name: {firstname} {lastname} Phone: {phone} Email: {email}");
            Console.WriteLine("The Next of Kin needs to be assigned to a camper.");
            AddNextOfKinToVisit();
        }/* Adds a new next of kin to the database */


        public void AddNextOfKinToVisit() /*Adds a next of kin and a camper to a visit*/
        {
            Console.WriteLine("Please enter the last name of the Next of Kin:");
            string nextName = Console.ReadLine();
            var nextOfKin = context.NextOfKins.Where(n => n.LastName == nextName).FirstOrDefault();
            int nextOfKinID = nextOfKin.NextOfKinID;

            Console.WriteLine("Please enter the last name of the Camper:");
            string camperName = Console.ReadLine();
            var camper = context.Campers.Where(c => c.LastName == camperName).FirstOrDefault();
            int camperID = camper.CamperID;

            DateTime now = DateTime.Now;
            Console.WriteLine("The Start Date of the visit will be Today, please enter the End Date of the visit (mm/dd/yyyy):");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());


            var nextOfKinVisitCount = context.NextOfKinVisit.Where(n => n.CamperID == camperID && n.DateEnd >= now).ToList();
            if (nextOfKinVisitCount.Count > 0)
            {
                Console.WriteLine("Error! There is already a Next of Kin visiting this camper. Please try later.");
                Console.ReadKey();
                Environment.Exit(1);
            }
            else
            {
                var nextOfKinVisit = new NextOfKinVisit { NextOfKinID = nextOfKinID, CamperID = camperID, DateStart = now, DateEnd = endDate };
                context.NextOfKinVisit.Add(nextOfKinVisit);
                context.SaveChanges();
                Console.WriteLine("The visit was added.");
            }
        }

        public void UpdateNextOfKin()
        {
            Console.WriteLine("First Name of the Next of Kin you want to Update:");
            string name = Console.ReadLine();
            var nextOfKin = context.NextOfKins.Where(c => c.FirstName == name).FirstOrDefault();
            if (nextOfKin is NextOfKin)
            {
                Console.WriteLine("Enter new first name:");
                string nextOfKinFirstName = Console.ReadLine();
                Console.WriteLine("Enter new last name:");
                string nextOfKinLastName = Console.ReadLine();
                Console.WriteLine("Enter new phone:");
                string nextOfKinPhone = Console.ReadLine();
                Console.WriteLine("Enter new email:");
                string nextOfKinEmail = Console.ReadLine();
                
                nextOfKin.FirstName = nextOfKinFirstName;
                nextOfKin.LastName = nextOfKinLastName;
                nextOfKin.Phone = nextOfKinPhone;
                nextOfKin.Email = nextOfKinEmail;

                context.SaveChanges();
                Console.WriteLine("Next of Kin was updated.");
            }
            else
            {
                Console.WriteLine("Next of Kin was not found.");
            }
        }/* Updates info about an existing next of kin */
        
        public void DeleteNextOfKin()
        {
            Console.WriteLine("Enter Last Name:");
            string name = Console.ReadLine();
            var nextOfKin = context.NextOfKins.Where(n => n.LastName == name).FirstOrDefault();
            int id = nextOfKin.NextOfKinID;
            DateTime now = DateTime.Now;
            var nextOfKinVisit = context.NextOfKinVisit.Where(nv => nv.NextOfKinID == id && nv.DateEnd >= now).FirstOrDefault();
            if (nextOfKinVisit != null)
            {
                Console.WriteLine("This Next of Kin could not be deleted because he/she is currently visiting a camper.");
            }
            else
            {
                context.Remove(nextOfKin);
                context.SaveChanges();
                Console.WriteLine("Next of Kin was Deleted.");
            }
        }/* Deletes a next of kin from the database */
        
        /*******************************************************************************************/
        
    }
}
