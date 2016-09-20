using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    public enum Sex
    {
        Male,
        Famale
    }

    public class Passenger
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Sex SexPass { get; set; }
        public FlyClass FClass { get; set; }

        public Passenger(string firstName, string secondName, string nationality,
            string passport, DateTime dateOfBirth, Sex sex, FlyClass fClass)
        {
            FirstName = firstName;
            SecondName = secondName;
            Nationality = nationality;
            Passport = passport;
            DateOfBirth = dateOfBirth.Date;
            SexPass = sex;
            FClass = fClass;
        }
        public void Add()
        {
            Console.WriteLine("Enter new First Name:");
            FirstName = Console.ReadLine();
            Console.WriteLine("Enter new Second Name:");
            SecondName = Console.ReadLine();
            Console.WriteLine("Enter new nationality:");
            Nationality = Console.ReadLine();
            Console.WriteLine("Enter new Passport:");
            Passport = Console.ReadLine();
            Console.WriteLine("Enter date of birth(dd/mm/yyyy)");
            DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter sex(Male/Famale):");
            SexPass = (Sex)Enum.Parse(typeof(Sex), Console.ReadLine());
            Console.WriteLine("Enter new class of flight(Business/Economy):");
            FlyClass fClass = new FlyClass((FlyC)Enum.Parse(typeof(FlyC), Console.ReadLine()));
        }

        public void EditPassenger()
        {
            Console.WriteLine("Enter ne First Name:");
            FirstName = Console.ReadLine();
            Console.WriteLine("Enter new Second Name:");
            SecondName = Console.ReadLine();
            Console.WriteLine("Enter new nationality:");
            Nationality = Console.ReadLine();
            Console.WriteLine("Enter new Passport:");
            Passport = Console.ReadLine();
            Console.WriteLine("Enter date of birth(dd/mm/yyyy)");
            DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter sex(Male/Famale):");
            SexPass = (Sex)Enum.Parse(typeof(Sex), Console.ReadLine());
            Console.WriteLine("Enter new class of flight(Business/Economy):");
            FClass.Flyclass = (FlyC)Enum.Parse(typeof(FlyC), Console.ReadLine());
        }
        public void DeletePassenger()
        {
            FirstName = null;
            SecondName = null;
            Nationality = null;
            Passport = null;
            DateOfBirth = new DateTime();
            SexPass = new Sex();
            FClass = null;
        }

        public void PrintPassengers()
        {
            Console.Write("| {0}", (FirstName.ToString()).PadRight(20));
            Console.Write("| {0}", (SecondName.ToString()).PadRight(20));
            Console.Write("| {0}", (Nationality.ToString()).PadRight(15));
            Console.Write("| {0}", (Passport.ToString()).PadRight(15));
            Console.Write("| {0}", (DateOfBirth.Date.ToString()).PadRight(12));
            Console.Write("| {0}", (SexPass.ToString()).PadRight(8));
            Console.WriteLine("| {0}", (FClass.Flyclass.ToString()).PadRight(12));
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------");
            //Console.WriteLine();
        }

        public void SearchPrintByFirstName(string FName)
        {
            if (FName == FirstName.ToString())
            {
                Console.Write("| {0}", (FirstName.ToString()).PadRight(20));
                Console.Write("| {0}", (SecondName.ToString()).PadRight(20));
                Console.Write("| {0}", (Nationality.ToString()).PadRight(15));
                Console.Write("| {0}", (Passport.ToString()).PadRight(15));
                Console.Write("| {0}", (DateOfBirth.Date.ToString()).PadRight(12));
                Console.Write("| {0}", (SexPass.ToString()).PadRight(8));
                Console.Write("| {0}", (FClass.Flyclass.ToString()).PadRight(12));
                Console.WriteLine();
            }
        }
        public void SearchPrintBySecondName(string SName)
        {
            if (SName == SecondName.ToString())
            {
                Console.Write("| {0}", (FirstName.ToString()).PadRight(20));
                Console.Write("| {0}", (SecondName.ToString()).PadRight(20));
                Console.Write("| {0}", (Nationality.ToString()).PadRight(15));
                Console.Write("| {0}", (Passport.ToString()).PadRight(15));
                Console.Write("| {0}", (DateOfBirth.Date.ToString()).PadRight(12));
                Console.Write("| {0}", (SexPass.ToString()).PadRight(8));
                Console.Write("| {0}", (FClass.Flyclass.ToString()).PadRight(12));
                Console.WriteLine();
            }
        }
        public void SearchPrintByPassport(string passport)
        {
            if (passport == Passport.ToString())
            {
                Console.Write("| {0}", (FirstName.ToString()).PadRight(20));
                Console.Write("| {0}", (SecondName.ToString()).PadRight(20));
                Console.Write("| {0}", (Nationality.ToString()).PadRight(15));
                Console.Write("| {0}", (Passport.ToString()).PadRight(15));
                Console.Write("| {0}", (DateOfBirth.Date.ToString()).PadRight(12));
                Console.Write("| {0}", (SexPass.ToString()).PadRight(8));
                Console.Write("| {0}", (FClass.Flyclass.ToString()).PadRight(12));
                Console.WriteLine();
            }
        }
    }
}
