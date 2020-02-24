using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ПР2
{
    class Program
    {

        //reads data from the keyboard and returns an array of Student-type objects
        static Student[] ReadStudentsArray()
        {
            string subject, teacher;
            int points;
            string name, surname, group;
            int year;
            double price;
            string paymentTime;
            
            int exam;

            Console.WriteLine("Enter the number of students: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Student[] students = new Student[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Student {i + 1}");
                Console.WriteLine("Enter a student name: ");
                name = Console.ReadLine();

                Console.WriteLine("Enter the student's last name: ");
                surname = Console.ReadLine();

                Console.WriteLine("Enter the student group code: ");
                group = Console.ReadLine();

                Console.WriteLine("Enter the student's course number: ");
                year = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How many exams did the student take? ");
                exam = Convert.ToInt32(Console.ReadLine());

                Result[] result = new Result[exam];
                for (int j = 0; j < exam; j++)
                {
                    Console.WriteLine($"Subject {j + 1}");
                    Console.WriteLine("The name of the subject: ");
                    subject = Console.ReadLine();
                    Console.WriteLine("Name of the teacher: ");
                    teacher = Console.ReadLine();
                    Console.WriteLine("Rating: ");
                    points = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    result[j] = new Result(subject, teacher, points);
                }
                Console.WriteLine("For what period the payment will be made? (1 - month, 2 - year, 3 - whole time)");
                n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter sum: ");
                price = Convert.ToDouble(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        paymentTime = "month";
                        break;
                    case 2:
                        paymentTime = "year";
                        break;
                    case 3:
                        paymentTime = "all of time";
                        break;
                    default:
                        Console.WriteLine("This choise doesn't exists!");
                        i--;
                        continue;
                }

                students[i] = new Student(name, surname, group, year, result, price, paymentTime);
            }
            return students;
        }

        //accepts a Student object and displays it
        static void PrintStudent(Student stude)
        {
            Console.WriteLine($"Name: {stude.Name}");
            Console.WriteLine($"Surname: {stude.Surname}");
            Console.WriteLine($"Group: {stude.Group}");
            Console.WriteLine($"Course: {stude.Year}");
            Console.WriteLine("Tuition fee: ");
            stude.printPrice();

            for( int i = 0; i < stude.Results.Count(); i++)
            {
                Console.WriteLine($"Subject {i + 1}");
                Console.WriteLine($"Name of the subject: {stude.Results[i].Subject}");
                Console.WriteLine($"Name of the teacher: {stude.Results[i].Teacher}");
                Console.WriteLine($"Rating: {stude.Results[i].Points}");
            }
        }

        //accepts an array of Student objects and displays it
        static void PrintStudents(Student[] stude)
        {
            for(int i = 0; i < stude.Count(); i++)
            {
                Console.WriteLine($"Name: {stude[i].Name}");
                Console.WriteLine($"Surname: {stude[i].Surname}");
                Console.WriteLine($"Group: {stude[i].Group}");
                Console.WriteLine($"Course: {stude[i].Year}");
                Console.WriteLine("Tuition fee: ");
                stude[i].printPrice();

                for (int j = 0; j < stude[i].Results.Count(); j++)
                {
                    Console.WriteLine($"Subject {j + 1}");
                    Console.WriteLine($"Name of the subject: {stude[i].Results[j].Subject}");
                    Console.WriteLine($"Name of the teacher: {stude[i].Results[j].Teacher}");
                    Console.WriteLine($"Rating: {stude[i].Results[j].Points}");
                }
            }
        }

        // accepts an array of Student objects
        // and returns the highest grade point average and the lowest grade point average through out-parameters
        static void GetStudentsInfo(Student[] stude, out double MaxAveragePoint, out double MinAveragePoint)
        {
            MaxAveragePoint = 0;
            MinAveragePoint = 101;

            for(int i = 0; i < stude.Count(); i++)
            {
                if (stude[i].GetAveragePoints() > MaxAveragePoint) {
                    MaxAveragePoint = stude[i].GetAveragePoints();
                }

                if (stude[i].GetAveragePoints() < MinAveragePoint)
                {
                    MinAveragePoint = stude[i].GetAveragePoints();
                }
            }
        }

        // takes an array of Student objects and sorts it by the student's grade point average
        static void SortStudentsByPoints(Student[] stude)
        {
            Array.Sort(stude, (s1, s2) => s1.GetAveragePoints().CompareTo(s2.GetAveragePoints()));       
        }

        // takes an array of Student objects and sorts it by name
        static void SortStudentsByName(Student[] stude)
        {
            Array.Sort(stude, (s1, s2) => s1.Surname.CompareTo(s2.Surname));
        }

        static void Main(string[] args)
        {
            bool isExit = false;
            int n, s;
            double MinPoint, MaxPoint;
            Student[] stude = ReadStudentsArray();
            while (!isExit)
            {
                Console.WriteLine();
                Console.WriteLine("1. Print information about one student.");
                Console.WriteLine("2. Output information about all students.");
                Console.WriteLine("3. Print the highest and lowest grade point average.");
                Console.WriteLine("4. Sort students by grade point average.");
                Console.WriteLine("5. Sort students by name.");
                Console.WriteLine("6. Exit.");

                n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (n)
                {
                    case 1:
                        Console.WriteLine($"Enter the student serial number: 0-{stude.Count() - 1} : ");
                        s = Convert.ToInt32(Console.ReadLine());
                        PrintStudent(stude[s]);
                        break;
                    case 2:
                        PrintStudents(stude);
                        break;
                    case 3:
                        GetStudentsInfo(stude, out MaxPoint, out MinPoint);
                        Console.WriteLine($"Min point: {MinPoint}");
                        Console.WriteLine($"Max Point: {MaxPoint}");
                        break;
                    case 4:
                        SortStudentsByPoints(stude);
                        break;
                    case 5:
                        SortStudentsByName(stude);
                        break;
                    case 6:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("This case doesn't exists!");
                        break;
                }
                Console.WriteLine();
            }

        }
    }
}
