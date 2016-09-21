using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    public class Application
    {
        public List<AirInfo> AirInfoList = new List<AirInfo>();
        public List<Passenger> Passengers = new List<Passenger>();
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WindowWidth = 159;
            Console.WindowHeight = 50;
            Console.SetWindowPosition(0, 0);
            int choise = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("1.View data about flight");
                Console.WriteLine("2.View data about passengers in Fligths");
                Console.WriteLine("3.Edit data about Flights");
                Console.WriteLine("4.Edit data about Passengers");
                Console.WriteLine("5.Search");
                Console.WriteLine("0. Exit");
                choise = int.Parse(Console.ReadLine());
                InitialisationLists();
                switch (choise)
                {
                    case 1:
                        {
                            PrintFlyInfo();
                            break;
                        }
                    case 2:
                        {
                            PrintPaasengerInfo();
                            break;
                        }

                    case 3:
                        {
                            EditFlight();
                            break;
                        }
                    case 4:
                        {
                            EditPassengers();
                            break;

                        }
                    case 5:
                        {
                            CustomSearch();
                            break;
                        }
                    default:
                        break;
                }
            }
            while (choise != 0);
        }

        static void PrintWithPriceTableHead()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("N| Date Arrival        | Date Departed         |Fligh N |City Arrival   | City Departured |");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
        }
        static void PrintTableHead()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("N |Date Arrival         | Date Departed         |Fligh N |City Arrival   | City Departured |Terminal|Flight Status|Gate");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
        }
        static void PrintPassTableHead()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("N |First Name           | Second Name         |Nationality     | Passport       | Date of Birth     | Sex     | Flight Class  ");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
        }
        public void InitialisationLists()
        {
            Passengers.Add(new Passenger("Petr", "Ivanov", "Ukraine", "098765", DateTime.Parse("01/08/1982").Date, Sex.Male, new FlyClass(FlyC.Ecocnomy)));

            AirInfoList.Add(new AirInfo(new FlightInformation(DateTime.Parse("27/08/2016 10:02:00"), DateTime.Parse("27/08/2016 08:10:00"),
              "KH8", "Kyiv", "Kharkov", "A", Status.Arrived, "86-10", new FlyClass(FlyC.Business) { Price = 1400 }, new FlyClass(FlyC.Ecocnomy) { Price = 700 }),
              new List<Passenger>(Passengers)));
            Passengers.Clear();
            Passengers.Add(new Passenger("Ivan", "Petrov", "Ukraine", "876543", DateTime.Parse("30/01/1992").Date, Sex.Male, new FlyClass(FlyC.Ecocnomy)));
            Passengers.Add(new Passenger("Tanya", "Lomonos", "Ukraine", "987654", DateTime.Parse("01/10/1986").Date, Sex.Famale, new FlyClass(FlyC.Business)));
            AirInfoList.Add(new AirInfo(new FlightInformation(DateTime.Parse("28/08/2016 22:08:00"), DateTime.Parse("28/08/2016 16:45:00"),
               "KY7", "Kyiv", "Paris", "B", Status.InFlight, "56-10", new FlyClass(FlyC.Business) { Price = 1600 }, new FlyClass(FlyC.Ecocnomy) { Price = 800 }),
               new List<Passenger>(Passengers)
               ));

            Passengers.Clear();

            Passengers.Add(new Passenger("Sergey", "Kapinos", "Russia", "333333", DateTime.Parse("08/03/1991").Date, Sex.Male, new FlyClass(FlyC.Ecocnomy)));
            Passengers.Add(new Passenger("Irina", "Sergeeva", "Ukraine", "444444", DateTime.Parse("21/07/1984").Date, Sex.Famale, new FlyClass(FlyC.Business)));
            AirInfoList.Add(new AirInfo(new FlightInformation(DateTime.Parse("28/08/2016 16:04:00"), DateTime.Parse("28/08/2016 12:16:00"),
               "PS9", "Lviv", "Milan", "C", Status.Arrived, "42-10", new FlyClass(FlyC.Business) { Price = 2000 }, new FlyClass(FlyC.Ecocnomy) { Price = 1100 }),
              new List<Passenger>(Passengers)
               ));
            Passengers.Clear();
        }
        public void PrintFlyInfo()
        {
            Console.Clear();
            Console.WriteLine("1.View information about Fligts");
            Console.WriteLine("2.View information about Flights with prices");
            Console.WriteLine("0.Back");
            int choiseCase1 = int.Parse(Console.ReadLine());
            if (choiseCase1 == 1)
            {
                PrintTableHead();
                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList[i].FlightI != null)
                    {

                        Console.Write(i + 1 + " ");
                        AirInfoList[i].FlightI.Print();
                    }
                }
                Console.ReadLine();
            }
            if (choiseCase1 == 2)
            {
                PrintWithPriceTableHead();
                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList[i].FlightI != null)
                    {

                        Console.Write(i + 1);
                        AirInfoList[i].FlightI.PrintWithPrices();
                    }
                }
                Console.ReadLine();
            }

            if (choiseCase1 == 0)
                return;
        }

        public void PrintPaasengerInfo()
        {
            Console.Clear();

            for (int i = 0; i < AirInfoList.Count; i++)
            {
                if (AirInfoList[i].FlightI != null)
                {
                    PrintTableHead();
                    Console.Write("{0} ", i + 1);

                    AirInfoList[i].FlightI.Print();
                    Console.WriteLine("Passengers in Fligth");
                    PrintPassTableHead();
                    for (int j = 0; j < AirInfoList[i].Passengers.Count; j++)
                    {

                        if (AirInfoList[i].Passengers != null)
                        {
                            Console.Write("{0} ", j + 1);
                            AirInfoList[i].Passengers[j].PrintPassengers();
                        }
                    }
                    Console.ReadLine();
                }
            }
            return;

        }

        public void EditFlight()
        {
            Console.Clear();
            Console.WriteLine("1. Add new Flight");
            Console.WriteLine("2. Edit  Flight");
            Console.WriteLine("3. Delete Flight");
            Console.WriteLine("0. Back");
            int choiseCase3 = int.Parse(Console.ReadLine());
            int iter = 0;
            if (choiseCase3 == 1)
            {


                AirInfoList.Add(new AirInfo(new FlightInformation(new DateTime(), new DateTime(), "0", "", "",
                  "", new Status(), ""), Passengers));
                iter = AirInfoList.Count;

                AirInfoList[iter - 1].FlightI.Add();
            }
            if (choiseCase3 == 2)
            {
                PrintTableHead();
                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList != null)
                    {

                        Console.Write((i + 1) + " ");
                        AirInfoList[i].FlightI.Print();
                    }
                }
                Console.WriteLine("Enter number position to edit");
                int iter2 = int.Parse(Console.ReadLine());
                AirInfoList[iter - 1].FlightI.Edit();
            }
            if (choiseCase3 == 3)
            {
                PrintPassTableHead();
                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList != null)
                    {

                        Console.WriteLine((i + 1) + " ");
                        AirInfoList[i].FlightI.Print();
                    }
                }
                Console.WriteLine("Enter number position to delete");
                int iter2 = int.Parse(Console.ReadLine());
                AirInfoList[iter2 - 1].FlightI.Delete();
            }
            if (choiseCase3 == 0)
                return;
        }
        public void EditPassengers()
        {
            Console.Clear();
            Console.WriteLine("1.Add passengers to Flight");
            Console.WriteLine("2.Edit information about passengers in Flight");
            Console.WriteLine("3. Delete passenger from Fligth");
            Console.WriteLine("0. Back");
            int choiseCase4 = int.Parse(Console.ReadLine());
            if (choiseCase4 == 1)
            {
                int choiseFlight = 0;
                PrintTableHead();
                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList[i] != null)
                    {

                        Console.WriteLine((i + 1) + " ");
                        AirInfoList[i].FlightI.Print();
                    }
                }
                Console.WriteLine("Enter N position");
                choiseFlight = int.Parse(Console.ReadLine());
                choiseFlight--;
                int choisePassenger = 0;
                for (int j = 0; j < AirInfoList[choiseFlight].Passengers.Count; j++)
                {
                    if (AirInfoList[choiseFlight].Passengers[j] == null)
                    {
                        choisePassenger = j;
                        break;
                    }
                }
                AirInfoList[choiseFlight].Passengers.Add(new Passenger("", "", "", "", new DateTime(), new Sex(), new FlyClass(FlyC.Business)));
                choisePassenger = AirInfoList[choiseFlight].Passengers.Count;
                AirInfoList[choiseFlight].Passengers[choisePassenger - 1].Add();
            }
            if (choiseCase4 == 2)
            {
                int choiseFlight = 0;
                PrintTableHead();
                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList != null)
                    {

                        Console.WriteLine(i + 1);
                        AirInfoList[i].FlightI.Print();
                    }
                }
                Console.WriteLine("Enter N position");
                choiseFlight = int.Parse(Console.ReadLine()) - 1;
                int choisePassenger = 0;
                PrintPassTableHead();
                for (int i = 0; i < AirInfoList[choiseFlight].Passengers.Count; i++)
                {
                    if (AirInfoList[choiseFlight].Passengers[i] != null)
                    {

                        Console.WriteLine(i + 1);
                        AirInfoList[choiseFlight].Passengers[i].PrintPassengers();
                    }
                }
                Console.WriteLine("Choise number of passenger");
                choisePassenger = int.Parse(Console.ReadLine());
                AirInfoList[choisePassenger].Passengers[choisePassenger].EditPassenger();

            }
            if (choiseCase4 == 3)
            {
                int choiseFlight = 0;
                PrintTableHead();
                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList != null)
                    {

                        Console.WriteLine(i + 1);
                        AirInfoList[i].FlightI.Print();
                    }
                }
                Console.WriteLine("Enter N position");
                choiseFlight = int.Parse(Console.ReadLine()) - 1;
                int choisePassenger = 0;
                PrintPassTableHead();
                for (int i = 0; i < AirInfoList[choiseFlight].Passengers.Count; i++)
                {
                    if (AirInfoList[choiseFlight].Passengers[i] != null)
                    {

                        Console.WriteLine(i + 1);
                        AirInfoList[choiseFlight].Passengers[i].PrintPassengers();
                    }
                }
                Console.WriteLine("Choise number of passenger to delete");
                choisePassenger = int.Parse(Console.ReadLine());
                AirInfoList[choisePassenger].Passengers[choisePassenger].DeletePassenger();

            }
            if (choiseCase4 == 1)
                return;

        }
        public void CustomSearch()
        {
            Console.Clear();
            Console.WriteLine("1.Search by Flight number");
            Console.WriteLine("2.Search by city Arrived");
            Console.WriteLine("3.Search by city Departure");
            Console.WriteLine("4.Search by price of Fligth");
            Console.WriteLine("5.Search by Firstname of passenger");
            Console.WriteLine("6.Search by SecondName of passenger");
            Console.WriteLine("7.Search by passport of passenger");
            Console.WriteLine("0.Back");
            int choiseCase5 = int.Parse(Console.ReadLine());

            if (choiseCase5 == 1)
            {
                Console.WriteLine("Enter Flight number");
                string choiseFlightNumber = Console.ReadLine();
                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList[i] != null)
                    {
                        if (AirInfoList[i].FlightI.FlightN == choiseFlightNumber)
                        {
                            PrintTableHead();
                            Console.Write("{0} ", i + 1);
                            AirInfoList[i].FlightI.SearchPrintByFNumber(choiseFlightNumber);
                        }
                    }
                }
                Console.ReadLine();
            }
            if (choiseCase5 == 2)
            {
                Console.WriteLine("Enter city Arrival");
                string choiseCityArrived = Console.ReadLine();
                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList[i] != null)
                    {
                        if (AirInfoList[i].FlightI.CityArrival == choiseCityArrived)
                        {
                            PrintTableHead();
                            Console.Write("{0} ", i + 1);
                            AirInfoList[i].FlightI.SearchPrintCityArrival(choiseCityArrived);
                        }
                    }
                }
                Console.ReadLine();
            }
            if (choiseCase5 == 3)
            {
                Console.WriteLine("Enter city Departure");
                string choiseCityDeparture = Console.ReadLine();
                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList[i] != null)
                    {
                        if (AirInfoList[i].FlightI.CityDeparture == choiseCityDeparture)
                        {
                            PrintTableHead();
                            Console.Write("{0} ", i + 1);
                            AirInfoList[i].FlightI.SearchPrintCityDeparture(choiseCityDeparture);
                        }
                    }
                }
                Console.ReadLine();
            }
            if (choiseCase5 == 4)
            {
                Console.WriteLine("Enter min price");
                float minPrice = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter max price");
                float maxPrice = float.Parse(Console.ReadLine());

                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList[i] != null)
                    {
                        PrintWithPriceTableHead();
                        Console.Write("{0} ", i + 1);
                        AirInfoList[i].FlightI.SearchByPrice(minPrice, maxPrice);
                    }
                }
                Console.ReadLine();
            }
            if (choiseCase5 == 5)
            {
                Console.WriteLine("Enter FirstName");
                string searchFirstName = Console.ReadLine();
                PrintTableHead();
                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList[i] != null)
                    {
                        for (int j = 0; j < AirInfoList[i].Passengers.Count; j++)
                        {
                            if (AirInfoList[i].Passengers[j].FirstName == searchFirstName)
                            {
                                Console.Write("{0} ", i + 1);
                                AirInfoList[i].FlightI.Print();
                                PrintPassTableHead();
                                AirInfoList[i].Passengers[j].SearchPrintByFirstName(searchFirstName);
                            }
                        }
                    }
                }
                Console.ReadLine();
            }
            if (choiseCase5 == 6)
            {
                Console.WriteLine("Enter SecondName");
                string searchSecondName = Console.ReadLine();
                PrintPassTableHead();
                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList[i] != null)
                    {

                        for (int j = 0; j < AirInfoList[i].Passengers.Count; j++)
                        {
                            if (AirInfoList[i].Passengers[j].SecondName == searchSecondName)
                            {
                                Console.Write("{0} ", i + 1);
                                AirInfoList[i].FlightI.Print();
                                PrintPassTableHead();
                                AirInfoList[i].Passengers[j].SearchPrintBySecondName(searchSecondName);
                            }
                        }
                    }
                }
                Console.ReadLine();
            }
            if (choiseCase5 == 7)
            {
                Console.WriteLine("Enter Passport number");
                string searchPassport = Console.ReadLine();
                PrintTableHead();
                for (int i = 0; i < AirInfoList.Count; i++)
                {
                    if (AirInfoList[i] != null)
                    {
                        for (int j = 0; j < AirInfoList[i].Passengers.Count; j++)
                        {
                            if (AirInfoList[i].Passengers[j].Passport == searchPassport)
                            {
                                Console.Write("{0} ", i + 1);
                                AirInfoList[i].FlightI.Print();
                                PrintPassTableHead();
                                AirInfoList[i].Passengers[j].SearchPrintByPassport(searchPassport);
                            }
                        }
                    }
                }
                if (choiseCase5 == 6)
                    return;
            }
            Console.ReadLine();
        }
    }
}






