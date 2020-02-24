using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
   public class Student
    {
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Group { set; get; }
        public int Year { set; get; }
        public double Price { set; get; }
        public string PaymentTime { set; get; }
        public Result[] Results { set; get; }
        public Student() { }
        public Student(string name, string surname, string group, int year, Result[] results, double price, string paymentTime)
        {
            Name = name;
            Surname = surname;
            Group = group;
            Year = year;
            Price = price;
            PaymentTime = paymentTime;
            Results = new Result[results.Count()];
            for (int i = 0; i < results.Count(); i++)
            {
                Results[i] = results[i];
            }
        }

        //calculates the arithmetic mean of all estimates
        public double GetAveragePoints()
        {
            int sum = 0;
            for (int i = 0; i < Results.Count(); i++)
            {
                sum += Results[i].Points;
            }
            return (Double)sum / Results.Count();
        }

        //returns the name of the subject by which the student has the highest score among other subjects
        public string GetBestSubject()
        {
            int MaxPoint = 0;
            int MaxIndex = 0;
            for (int i = 0; i < Results.Count(); i++)
            {
                if (Results[i].Points > MaxPoint)
                {
                    MaxPoint = Results[i].Points;
                    MaxIndex = i;
                }
            }
            return Results[MaxIndex].Subject;
        }

        //returns the name of the subject that gave the student the worst score.
        public string GetWorstSubject()
        {
            int MinPoint = 101;
            int MinIndex = 0;
            for (int i = 0; i < Results.Count(); i++)
            {
                if (Results[i].Points < MinPoint)
                {
                    MinPoint = Results[i].Points;
                    MinIndex = i;
                }
            }
            return Results[MinIndex].Subject;
        }

        public void printPrice()
        {
            if (PaymentTime == "month")
            {
                Console.WriteLine($"Monthly payment {Price}");
                Console.WriteLine($"Payment for the year {Price * 12}");
                Console.WriteLine($"For the entire period of payment {Price * 40}");
            }
            if (PaymentTime == "year")
            {
                Console.WriteLine($"Monthly payment {Price / 12}");
                Console.WriteLine($"Payment for the year {Price}");
                Console.WriteLine($"For the entire period of payment {Price / 12 * 40}");
            }
            if (PaymentTime == "all of time")
            {
                Console.WriteLine($"Monthly payment {Price / 40}");
                Console.WriteLine($"Payment for the year {Price / 40 * 12}");
                Console.WriteLine($"For the entire period of payment {Price}");
            }
        }
    }
}
