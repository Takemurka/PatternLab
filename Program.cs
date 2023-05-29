using System;
using System.Runtime.InteropServices;

namespace Patterns
    {
        class Program
        {

            public static void PrinterBlock1Printer(Lecture lecture)
            {
                Console.WriteLine("Lecture Information:");
                Console.WriteLine("Title: " + lecture.Title);
                Console.WriteLine("Lector: " + lecture.Lector);
                Console.WriteLine("Students: ");
                foreach (var student in lecture.Students)
                {
                    Console.WriteLine("- " + student.FirstName + " " + student.LastName);
                }
                Console.WriteLine("Literature References: ");
                foreach (var reference in lecture.LiteratureReferences)
                {
                    Console.WriteLine("- " + reference.Location + ", Page: " + reference.Page);
                }
            }
            
            public static void Main(string[] args){
                Console.WriteLine("Select block (1-2-3) :");
                int switcher = int.Parse(Console.ReadLine());
                switch (switcher)
                {
                    case 1:
                        Lecture lecture = new LectureBuilder()
                            .SetTitle("Programming product creation technology")
                            .SetLector("Voevodin Evgenij Volodomyrovych")
                            .AddStudent("Anton", "Sukhobrus")
                            .AddStudent("Vitaliy", "Kylchutskiy")
                            .AddLiteratureReference("Licture reference (1)", 10)
                            .AddLiteratureReference("Licture reference (2)", 20)
                            .Build();

                        PrinterBlock1Printer(lecture);
                        break;
                    case 2:
                        IClient client = new Client("12345");
                        IClient rateLimitedClient = new RateLimitedClientDecorator(client, 10, TimeSpan.FromMinutes(1));

                        for (int i = 0; i < 15; i++)
                        {
                            try
                            {
                                string content = rateLimitedClient.GetContent("abc");
                                Console.WriteLine("Content: " + content);
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine("Rate limit exceeded: " + ex.Message);
                            }
                        }
                        break;
                    case 3:
                        List<Student> students = new List<Student>
                        {
                            new Student("Anton","Sukhobrus",true),
                            new Student("Vitaliy","Kulchitsky",true),
                            new Student("Yaroslav","Lynyk",false),
                            new Student("Antonuk","Oleksandr",false),
                        };
                        IStudentStrategy randomSelectionStrategy = new RandomSelection();
                        StudentManager randomStudentManager = new StudentManager(students, randomSelectionStrategy);

                        IStudentStrategy notAnsweredSelectionStrategy = new NotAnsweredSelection();
                        StudentManager notAnsweredStudentManager = new StudentManager(students, notAnsweredSelectionStrategy);


                        Student randomStudent = randomStudentManager.SelectStudent();
                        Console.WriteLine("Random Student: " + randomStudent.FirstName+ " " + randomStudent.LastName);
                        
                        Student notAnsweredStudent = notAnsweredStudentManager.SelectStudent();
                        Console.WriteLine("Not Answered Student: " + notAnsweredStudent.FirstName+ " " + notAnsweredStudent.LastName);
                        
                        break;
                    default:
                        Console.WriteLine("Wrong option selected. Ending.....");
                        break;
                }
               
            }
        }
    }