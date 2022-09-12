using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slutuppgift_Camp_Julia.Models;
using Slutuppgift_Camp_Julia.Data;


namespace Slutuppgift_Camp_Julia
{
    class Program
    {

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.SetUpSeed();
            program.MainMenu();
        }

        public Methods useMethods = new Methods();

        //public void SetUpSeed()
        //{

        //    SeedCamp seedCamp = new SeedCamp();
        //    seedCamp.AddSeedData();
        //    seedCamp.SeedCamperStay();
        //    seedCamp.SeedCouncelorStay();
        //    seedCamp.SeedNextOfKinVisits();

        //}

        public void MainMenu()
        {
            Console.WriteLine("Welcome! What would you like to access? \n1. Campers" +
                "\n2. Councelors \n3. Cabins \n4. Next Of Kins \n5. Exit program");

            int input = Int32.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    CampersMenu();
                    break;
                case 2:
                    CouncelorsMenu();
                    break;
                case 3:
                    CabinMenu();
                    break;
                case 4:
                    NextOfKinsMenu();
                    break;
                case 5:
                    System.Environment.Exit(1);
                    break;

                default:
                    Console.WriteLine("Something went wrong please try again.");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }
        public void CampersMenu()
        {
            Console.WriteLine("1. Add a new Camper \n2. Add Camper to Cabin \n3. Update info about a Camper" +
                "\n4. Delete camper \n5. Search for Campers based on a Cabin \n6. Search for Campers based on a Councelor" +
                "\n7. View Camper Stay History");
            int input = Int32.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    useMethods.AddNewCamper();
                    break;
                case 2:
                    useMethods.AddCamperToStay();
                    break;
                case 3:
                    useMethods.UpdateCamper();
                    break;
                case 4:
                    useMethods.DeleteCamper();
                    break;
                case 5:
                    useMethods.SearchCampersByCabin();
                    break;
                case 6:
                    useMethods.SearchCampersByCouncelor();
                    break;
                case 7:
                    useMethods.HistoryCamperStays();
                    break;

                default:
                    Console.WriteLine("Something went wrong please try again.");
                    Console.ReadKey();
                    CampersMenu();
                    break;
            }

        }

        public void CouncelorsMenu()
        {
            Console.WriteLine("1. Add a new Councelor \n2. Add Councelor to Cabin \n3. Update info about Councelor \n4. Delete a Councelor");
            int input = Int32.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    useMethods.AddNewCouncelor();
                    break;
                case 2:
                    useMethods.AddCouncelorToStay();
                    break;
                case 3:
                    useMethods.UpdateCouncelor();
                    break;
                case 4:
                    useMethods.DeleteCouncelor();
                    break;

                default:
                    Console.WriteLine("Something went wrong please try again.");
                    Console.ReadKey();
                    CouncelorsMenu();
                    break;
            }

        }
        public void CabinMenu()
        {
            Console.WriteLine("1. Add a new Cabin \n2. Update info about a Cabin \n3. Delete Cabin");
            int input = Int32.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    useMethods.AddNewCabin();
                    break;
                case 2:
                    useMethods.UpdateCabin();
                    break;
                case 3:
                    useMethods.DeleteCabin();
                    break;

                default:
                    Console.WriteLine("Something went wrong please try again.");
                    Console.ReadKey();
                    CampersMenu();
                    break;
            }

        }
        public void NextOfKinsMenu()
        {
            Console.WriteLine("1. Add a new Next Of Kin \n2. Add a Next Of Kin to a Visit with a Camper \n3. Update info about a Next Of Kin \n4. Delete a Next Of Kin");
            int input = Int32.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    useMethods.AddNewNextOfKin();
                    break;
                case 2:
                    useMethods.AddNextOfKinToVisit();
                    break;
                case 3:
                    useMethods.UpdateNextOfKin();
                    break;
                case 4:
                    useMethods.DeleteNextOfKin();
                    break;

                default:
                    Console.WriteLine("Something went wrong please try again.");
                    Console.ReadKey();
                    NextOfKinsMenu();
                    break;
            }

        }
    }

}
