using System;

namespace ElectronicGradeBook
{
    class Program
    {
        /// <summary>
        /// This is an assignment to practice basic and important C# knowledge.
        ///Requirement: Create an electronic grade book to read grades of an individual student:
        ///1.	Show options to save the grade book in memory(InMemoryBook) or in a file(DiskBook)
        ///2.	Then compute some simple statistics from the scores
        ///3.	The grades must be floating point numbers from 0 to 100
        ///4.	Statistics should show the highest grade, lowest grade, and the average grade
        ///Constraints:
        ///-	Use pillars of OOP(Inheritance, Polymorphism, Encapsulation , Abstraction) - interface, abstract classes, delegate and event (GradeAdded)
        ///-	Catch exception in case users enter invalid grades using try catch
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("REQUIREMENT:\n" +
                "\tCreate an electronic grade book to read grades of an individual student:\n" +
                "\t1.	Show options to save the grade book in memory(InMemoryBook) or in a file(DiskBook)\n" +
                "\t2.	Then compute some simple statistics from the scores\n" +
                "\t3.	The grades must be floating point numbers from 0 to 100\n" +
                "\t4.	Statistics should show the highest grade, lowest grade, and the average grade\n" +
                "CONSTRAINTS:\n" +
                "\t-	Use pillars of OOP(Inheritance, Polymorphism, Encapsulation) -\n" +
                "\t\tinterface, abstract classes, delegate and event (GradeAdded)\n" +
                "\t-	Catch exception in case users enter invalid grades using try catch\n" +
                "***************************************************************************************\n");
            Console.Write("Enter Book Name: ");
            var bookName = Console.ReadLine();
            Book book = null;
            int saveType;
            Console.Write("Enter 1 to save grades in memory or 2 to save grades to a file: ");
            while (true)
            {
                try
                {
                    saveType = int.Parse(Console.ReadLine());
                    if (saveType == 1)
                    {
                        book = new InMemoryBook(bookName);
                        break;
                    }
                    else if (saveType == 2)
                    {
                        book = new DiskBook(bookName);
                        break;
                    }
                    else
                    {
                        Console.Write("Enter 1 to save grades in memory or 2 to save grades to a file: ");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Enter 1 to save grades in memory or 2 to save grades to a file: ");
                }
            }
            book.GradeAdded += OnGradeAdded;
            EnterGrade(book);
            var stats = book.GetStatistics();
            Console.WriteLine("\nBook Information:\n");
            Console.WriteLine("\tBook Name: " + book.Name + "\n");
            Console.WriteLine($"\tThe lowest grade: {stats.Low}");
            Console.WriteLine($"\tThe highest grade: {stats.High}");
            Console.WriteLine($"\tThe average grade: {stats.Average}");
            Console.WriteLine($"\tThe letter grade: {stats.Letter}");
            Console.ReadLine();
        }
        private static void EnterGrade(Book book)
        {
            while (true)
            {
                Console.Write("\nEnter a grade or 'q' to quit:");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }
    }
}