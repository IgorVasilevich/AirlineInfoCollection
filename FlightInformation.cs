using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    public enum Status
    {
        CheckIn,
        GateClosed,
        Arrived,
        DepartedAt,
        Unknown,
        Canseled,
        ExpectedAt,
        Delayed,
        InFlight
    }

    public class FlightInformation : IEnumerator
    {
        public event Action OnFlightPrint;

        public DateTime DTArrival { get; set; }
        public DateTime DTDeparture { get; set; }
        public string FlightN { get; set; }
        public string CityArrival { get; set; }
        public string CityDeparture { get; set; }
        public string Terminal { get; set; }
        public Status FlightStatus { get; set; }
        public string Gate { get; set; }
        public FlyClass[] FClass { get; set; }

        int position = -1;
        public FlightInformation[] flight;

        public object Current
        {
            get
            {
                return position;
            }
        }

        public FlightInformation(DateTime dtArrival, DateTime dtDeparture, string flightN,
            string cityArrival, string cityDeparture, string terminal,
            Status flightStatus, string gate, params FlyClass[] fClass)
        {
            DTArrival = dtArrival;
            DTDeparture = dtDeparture;
            FlightN = flightN;
            CityArrival = cityArrival;
            CityDeparture = cityDeparture;
            Terminal = terminal;
            FlightStatus = flightStatus;
            Gate = gate;
            FClass = fClass;
        }

        public void Add()
        {
            Console.WriteLine("Enter new date and time arrival(dd/mm/yyyy hh:mm:ss)");
            DTArrival = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter new date and time departure(dd/mm/yyyy hh:mm:ss)");
            DTDeparture = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter new FlightNumber:");
            FlightN = Console.ReadLine();
            Console.WriteLine("Enter new city of arrival:");
            CityArrival = Console.ReadLine();
            Console.WriteLine("Enter new city of departure:");
            CityDeparture = Console.ReadLine();
            Console.WriteLine("Enter new terminal:");
            Terminal = Console.ReadLine();
            Console.WriteLine("Enter new flight status:");
            FlightStatus = (Status)Enum.Parse(typeof(Status), Console.ReadLine());
            Console.WriteLine("Enter new gate:");
            Gate = Console.ReadLine();
            for (int i = 0; i < FClass.Length; i++)
            {
                Console.WriteLine("Enter price for {0}", FClass[i].Flyclass);
                FClass[i].Price = float.Parse(Console.ReadLine());
            }

        }

        public void Delete()
        {
            DTArrival = new DateTime();
            DTDeparture = new DateTime();
            FlightN = null;
            CityArrival = null;
            CityDeparture = null;
            Terminal = null;
            FlightStatus = new Status();
            Gate = null;
            FClass = null;
        }

        public void Edit()
        {
            Console.WriteLine("Enter new date and time arrival(dd/mm/yyyy hh:mm:ss)");
            DTArrival = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter new date and time departure(dd/mm/yyyy hh:mm:ss)");
            DTDeparture = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter new FlightNumber:");
            FlightN = Console.ReadLine();
            Console.WriteLine("Enter new FlightNumber:");
            FlightN = Console.ReadLine();
            Console.WriteLine("Enter new city of arrival:");
            CityArrival = Console.ReadLine();
            Console.WriteLine("Enter new city of departure:");
            CityDeparture = Console.ReadLine();
            Console.WriteLine("Enter new terminal:");
            Terminal = Console.ReadLine();
            Console.WriteLine("Enter new flight status:");
            FlightStatus = (Status)Enum.Parse(typeof(Status), Console.ReadLine());
            Console.WriteLine("Enter new gate:");
            Gate = Console.ReadLine();
            for (int i = 0; i < FClass.Length; i++)
            {
                Console.WriteLine("Enter price for {0}", FClass[i].Flyclass);
                FClass[i].Price = float.Parse(Console.ReadLine());
            }
        }


        public void Print()
        {
            Console.Write("|{0}", DTArrival.ToString().PadRight(21));
            Console.Write("|{0}", DTDeparture.ToString().PadRight(23));
            Console.Write("|{0}", FlightN.PadRight(8));
            Console.Write("|{0}", CityArrival.PadRight(15));
            Console.Write("|{0}", CityDeparture.PadRight(17));
            Console.Write("|{0}", Terminal.PadRight(8));
            Console.Write("|{0}", (FlightStatus.ToString()).PadRight(13));
            Console.Write("|{0}", Gate.PadRight(8));
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
        }


        public void PrintWithPrices()
        {
            Console.Write("|{0}", DTArrival.ToString().PadRight(21));
            Console.Write("|{0}", DTDeparture.ToString().PadRight(23));
            Console.Write("|{0}", FlightN.PadRight(8));
            Console.Write("|{0}", CityArrival.PadRight(15));
            Console.Write("|{0}", CityDeparture.PadRight(17));
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < FClass.Length; i++)
            {
                Console.WriteLine("Price for {0} class:{1}", FClass[i].Flyclass, FClass[i].Price);
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void SearchByPrice(float min, float max)
        {
            for (int i = 0; i < FClass.Length; i++)
            {
                if (min <= FClass[i].Price && FClass[i].Price <= max)
                {
                    PrintWithPrices();
                }
            }
        }

        public void SearchPrintByFNumber(string fnumber)
        {
            if (fnumber == FlightN.ToString())
            {
                Console.Write("|{0}", DTArrival.ToString().PadRight(21));
                Console.Write("|{0}", DTDeparture.ToString().PadRight(23));
                Console.Write("|{0}", FlightN.PadRight(8));
                Console.Write("|{0}", CityArrival.PadRight(15));
                Console.Write("|{0}", CityDeparture.PadRight(17));
                Console.Write("|{0}", Terminal.PadRight(8));
                Console.Write("|{0}", (FlightStatus.ToString()).PadRight(13));
                Console.Write("|{0}", Gate.PadRight(8));
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
                for (int i = 0; i < FClass.Length; i++)
                {
                    Console.WriteLine("Price for {0}class:{1}", FClass[i].Flyclass, FClass[i].Price);
                }
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public void SearchPrintCityArrival(string cityArrival)
        {
            if (cityArrival == CityArrival.ToString())
            {
                Console.Write("|{0}", DTArrival.ToString().PadRight(21));
                Console.Write("|{0}", DTDeparture.ToString().PadRight(23));
                Console.Write("|{0}", FlightN.PadRight(8));
                Console.Write("|{0}", CityArrival.PadRight(15));
                Console.Write("|{0}", CityDeparture.PadRight(17));
                Console.Write("|{0}", Terminal.PadRight(8));
                Console.Write("|{0}", (FlightStatus.ToString()).PadRight(13));
                Console.Write("|{0}", Gate.PadRight(8));
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
                for (int i = 0; i < FClass.Length; i++)
                {
                    Console.WriteLine("Price for {0}class:{1}", FClass[i].Flyclass, FClass[i].Price);
                }
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public void SearchPrintCityDeparture(string cityDeparture)
        {
            if (cityDeparture == CityDeparture.ToString())
            {
                Console.Write("|{0}", DTArrival.ToString().PadRight(21));
                Console.Write("|{0}", DTDeparture.ToString().PadRight(23));
                Console.Write("|{0}", FlightN.PadRight(8));
                Console.Write("|{0}", CityArrival.PadRight(15));
                Console.Write("|{0}", CityDeparture.PadRight(17));
                Console.Write("|{0}", Terminal.PadRight(8));
                Console.Write("|{0}", (FlightStatus.ToString()).PadRight(13));
                Console.Write("|{0}", Gate.PadRight(8));
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
                for (int i = 0; i < FClass.Length; i++)
                {
                    Console.WriteLine("Price for {0}class:{1}", FClass[i].Flyclass, FClass[i].Price);
                }
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < flight.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
