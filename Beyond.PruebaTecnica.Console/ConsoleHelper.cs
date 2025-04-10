using System;
using System.Globalization;

namespace Beyond.PruebaTecnica.ConsoleApp
{
    public static class ConsoleHelper
    {
        public static void WriteHeader(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"=== {title.ToUpper()}");
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();
        }

        public static DateTime ReadDateTime()
        {
            DateTime datePart;
            Console.Write("Date (yyyy-MM-dd): ");
            while (!DateTime.TryParseExact(Console.ReadLine()!, "yyyy-MM-dd", null, DateTimeStyles.None, out datePart))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid format. Please use yyyy-MM-dd: ");
                Console.ResetColor();
            }

            TimeSpan timePart;
            Console.Write("Time (HH:mm:ss): ");
            while (!TimeSpan.TryParseExact(Console.ReadLine()!, "hh\\:mm\\:ss", null, out timePart))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid format. Please use HH:mm:ss: ");
                Console.ResetColor();
            }

            return datePart.Date + timePart;
        }

        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[ERROR] {message}");
            Console.ResetColor();
        }

        public static void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n[OK] {message}");
            Console.ResetColor();
        }
    }
}
