using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BelgiumCafeteria
{
    internal class Program
    {
        enum Menu
        {
            CaptureDetails = 1,
            CheckDiscountQualification,
            ShowQualificationStatus,
            Exit
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Student> qualifiedStudents = new List<Student>();
            int studentID = 1;

            bool capturing = true;

            while (capturing)
            {
                Console.WriteLine("\nMain Menu");
                Console.WriteLine("1. Capture Details");
                Console.WriteLine("2. Check Discount Qualification");
                Console.WriteLine("3. Show Qualification Status");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && Enum.IsDefined(typeof(Menu), choice))
                {
                    Menu selectedOption = (Menu)choice;

                    switch (selectedOption)
                    {
                        case Menu.CaptureDetails:
                            List<Student> newStudents = CaptureStudent(studentID);
                            students.AddRange(newStudents);
                            studentID += newStudents.Count;
                            break;

                        case Menu.CheckDiscountQualification:
                            qualifiedStudents = DiscountQual(students);
                            break;

                        case Menu.ShowQualificationStatus:
                            Console.WriteLine("\nQualification Status");
                            if (qualifiedStudents.Count > 0)
                            {
                                foreach (var s in qualifiedStudents)
                                {
                                    Console.WriteLine($"{s.FullName} qualifies for a discount.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No students have qualified yet.");
                            }
                            break;

                        case Menu.Exit:
                            Console.WriteLine("Exiting the program...");
                            capturing = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static List<Student> CaptureStudent(int startingID)
        {
            List<Student> students = new List<Student>();
            int studentID = startingID;
            bool more = true;

            while (more)
            {
                Console.WriteLine("\nEnter full student's name: ");
                string fullName = Console.ReadLine();

                Console.WriteLine("Is the student a residence student? (Y/N):");
                bool isResStudent = Console.ReadLine().ToUpper() == "Y";

                Console.WriteLine("Years on campus: ");
                int yearsOnCampus;
                while (!int.TryParse(Console.ReadLine(), out yearsOnCampus) || yearsOnCampus < 0)
                {
                    Console.WriteLine("Invalid input. Enter a positive number:");
                }

                Console.WriteLine("Enter years at current residence: ");
                int yearsAtRes;
                while (!int.TryParse(Console.ReadLine(), out yearsAtRes) || yearsAtRes < 0)
                {
                    Console.WriteLine("Invalid input. Enter a positive number:");
                }

                Console.WriteLine("Enter Monthly allowance: ");
                decimal allowance;
                while (!decimal.TryParse(Console.ReadLine(), out allowance) || allowance < 0)
                {
                    Console.WriteLine("Invalid input. Enter a valid amount:");
                }

                Console.WriteLine("Average mark across all subjects: ");
                double avgMark;
                while (!double.TryParse(Console.ReadLine(), out avgMark) || avgMark < 0 || avgMark > 100)
                {
                    Console.WriteLine("Invalid. Enter a percentage between 0-100");
                }

                students.Add(new Student(studentID++, fullName, isResStudent, yearsOnCampus, yearsAtRes, allowance, avgMark));

                Console.WriteLine("\nDo you want to capture another student? (Y/N): ");
                more = Console.ReadLine().ToLower() == "y";
            }

            return students;
        }

        static List<Student> DiscountQual(List<Student> students)
        {
            List<Student> qualified = new List<Student>();

            foreach (var student in students)
            {
                if (student.YearsOnCampus > 1 && student.IsResStudent && student.AvgMark > 85 && student.Allowance <= 1000)
                {
                    Console.WriteLine($"{student.FullName} qualifies for a discount.");
                    qualified.Add(student);
                }
                else
                {
                    Console.WriteLine($"{student.FullName} does not qualify for a discount.");
                }
            }

            return qualified;
        }
    }
}
