using System;
using System.Linq;

namespace Welcome
{
    class Program
    {
        private static int dayOfBirth;
        private static int monthOfBirth;                
        
        private static int GetDayInputNumber()
        {
            int input; //deklaracja zmiennej, której wartość będzie zwracana z metody

            while (true) //nieskończona pętla, jej działanie zakończy instrukcja break
            {
                if (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 31) //jeżeli wprowadzona wartość nie jest liczbą
                    Console.WriteLine("Podałeś nieprawidłowe dane! Spróbuj ponownie.\nWprowadź wartość liczbową z przedziału 1-31."); //to wyświetl komunikat
                else //jeżeli wartość jest liczbą
                    break; //to wyjdź z pętli
            }
                return input; //zwróć liczbę wpisaną przez użytkownika
        }

        private static int GetMonthInputNumber()
        {
            int input;

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 12)
                    Console.WriteLine("Podałeś nieprawidłowe dane! Spróbuj ponownie.\nWprowadź wartość liczbową z przedziału 1-12.");
                else
                    break;
            }
            return input;
        }

        private static int GetYearInputNumber()
        {
            int input;
            


            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out input) || input < 1900 || input > DateTime.Now.Year)
                    Console.WriteLine("Podałeś nieprawidłowe dane! Spróbuj ponownie.\nWprowadź wartość liczbową z przedziału 1900-" + DateTime.Now.Year + ".");
                else
                    break;               
            }
            return input;
        }

        private static string NameIsLetter()
        {
            var name = string.Empty;
            
            while (true)
            {
                name = Console.ReadLine();
                var result = name.All(Char.IsLetter);
                
                if (!result) 
                   Console.WriteLine("Podałeś nieprawidłowe dane! Spróbuj ponownie.\nImię składa się wyłącznie z liter.");
                else
                    break;
            }
            return name;
        }

        private static string PlaceIsLetterOrSpace()
        {
            var placeOfBirth = string.Empty;

            while (true)
            {
                placeOfBirth = Console.ReadLine();
                var result = placeOfBirth
                    .All(c => char.IsLetter(c) || c == ' ' || c == '-');

                if (!result)
                    Console.WriteLine("Podałeś nieprawidłowe dane! Spróbuj ponownie.\nNazwa miejscowości składa się wyłącznie z liter.");
                else
                    break;
            }
            return placeOfBirth;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w programie Time 4U!");
            Console.WriteLine("==========================");
            Console.WriteLine("");
            Console.WriteLine("Podaj proszę swoje imię:");
            var name = NameIsLetter();        
            Console.WriteLine("");
            
            Console.WriteLine("Wprowadź swoją datę i miejsce urodzenia:");
            Console.WriteLine("Dzień:");            
            int dayOfBirth = GetDayInputNumber();
            
            Console.WriteLine("Miesiąc:");
            int monthOfBirth = GetMonthInputNumber();

            Console.WriteLine("Rok:");
            int yearOfBirth = GetYearInputNumber();
           
            Console.WriteLine("Miejsce urodzenia:");
            var placeOfBirth = PlaceIsLetterOrSpace();
            Console.WriteLine("");


            DateTime dateOfBirth = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
            
            var today = DateTime.Now;

            int yearOfAge;

            if (dateOfBirth > DateTime.Now)
            {
                Console.WriteLine("Podałeś nieprawidłowy rok urodzenia! Spróbuj ponownie.");
                return;
            }

            if (dateOfBirth.DayOfYear < today.DayOfYear)
                yearOfAge = today.Year - dateOfBirth.Year;
            else
                yearOfAge = today.Year - dateOfBirth.Year - 1;           
                
            Console.WriteLine("Cześć " + name + "!");
                Console.WriteLine("Urodziłeś się w miejscowości " + placeOfBirth + " " + "i masz " + yearOfAge + " lat.");            
        }
    }
}