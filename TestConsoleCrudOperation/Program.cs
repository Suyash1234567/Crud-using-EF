using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleCrudOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.Menu();
            Console.WriteLine("Enter 1 to Create new course record \n" +
                "Enter 2 to Create new student record \n" +
                "Enter 3 to Retrieve student record \n" +
                "Enter 4 to Update student record \n" +
                "Enter 5 to Delete student record \n" +
                "Enter 6 to exit");
            string userChoice = Console.ReadLine();
            int userInput = Convert.ToInt32(userChoice);
            bool isCheck = true;
            while (isCheck)
            {
                if (userInput == 1)
                {
                    program.AddCourse();
                    Console.ReadLine();
                }
                if (userInput == 2)
                {
                    program.CreateStudent();
                    Console.ReadLine();
                }
                if (userInput == 3)
                {
                    program.RetrieveStudent();
                    Console.ReadLine();
                }
                if (userInput == 4)
                {
                    program.UpdateStudent();
                    Console.ReadLine();
                }
                if (userInput == 5)
                {
                    program.DeleteStudent();
                    Console.ReadLine();
                }
                if (userInput == 6)
                {
                    isCheck = false;
                }
            }

            //CreateStudent();
            //RetrieveStudent();
            //UpdateStudent();
            //DeleteStudent();
            //Console.ReadLine();
        }

        public int Menu()
        {
            Console.WriteLine("Enter 1 to Create new course record \n" +
              "Enter 2 to Create new student record \n" +
              "Enter 3 to Retrieve student record \n" +
              "Enter 4 to Update student record \n" +
              "Enter 5 to Delete student record \n" +
              "Enter 6 to exit");
            string userChoice = Console.ReadLine();
            int userInput = Convert.ToInt32(userChoice);
            return userInput;
        }

        private void AddCourse()
        {
            using (StudentModel model = new StudentModel())
            {
                //Since Id is self generated (cause of primary key) it won't be taken in as input form user
                Console.WriteLine("Enter course name");
                string CName = Console.ReadLine();
                CourseViewModel course = new CourseViewModel()
                {
                    CourseName=CName
                };
                model.Courses.Add(course);
                model.SaveChanges();
            }
        }

        private void CreateStudent()
        {
            using (StudentModel model = new StudentModel())
            {
                Console.WriteLine("Enter student name");
                string SName = Console.ReadLine();
                Console.WriteLine("Enter student class");
                string StudentChoice1 = Console.ReadLine();
                int SClass = Convert.ToInt32(StudentChoice1);

                Console.WriteLine("Enter your choice");

                foreach(var item in model.Courses)
                {
                    Console.WriteLine(item.CourseName + "   For   " + item.CourseId);
                }
                int courseId = Convert.ToInt32(Console.ReadLine());

                StudentViewModel student = new StudentViewModel()
                {
                    StudentName = SName,
                    StudentClass = SClass,
                    CourseId = courseId
                };
            }
        }

        private void RetrieveStudent()
        {
            StudentModel context = new StudentModel();
            var students = context.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine(student.StudentId);
                Console.WriteLine(student.StudentName);
                Console.WriteLine(student.StudentClass);
                Console.ReadLine();
            }
        }

        private void UpdateStudent()
        {
            using (StudentModel model = new StudentModel())
            {
                Console.WriteLine("Enter Student ID for update");
                string SId = Console.ReadLine();
                int StId = Convert.ToInt32(SId);
                StudentViewModel student = model.Students.Where(s => s.StudentId == StId).FirstOrDefault();
                if (student != null)
                {
                    Console.Write("Enter Student Name: ");
                    string studentName = Console.ReadLine();
                    Console.WriteLine("Enteer Student class");
                    string stClass = Console.ReadLine();
                    int studentClass = Convert.ToInt32(stClass);

                    Console.WriteLine("Enter your choice: ");
                    foreach (var item in model.Courses)
                    {
                        Console.WriteLine(item.CourseName + "   For   " + item.CourseId);

                    }
                    int courseID = Convert.ToInt32(Console.ReadLine());

                    student.StudentName = studentName;
                    student.StudentClass = studentClass;
                    student.CourseId = courseID;
                }
                else
                {
                    Console.WriteLine("Student ID not Found ");
                    model.SaveChanges();
                }
            }
        }

        private void DeleteStudent()
        {
            using (StudentModel model = new StudentModel())
            {
                Console.Write("Enter Student ID  :  ");
                int StId = Convert.ToInt32(Console.ReadLine());
                StudentViewModel student = model.Students.Where(x => x.StudentId == StId).FirstOrDefault();
                if (student != null)
                {
                    model.Students.Remove(student);
                }
                else
                {
                    Console.WriteLine("Student ID not Found ");
                }
                model.SaveChanges();
            }
            //StudentModel context = new StudentModel();
            //var student = context.Students.FirstOrDefault(s => s.StudentName == "Yash");
            //context.Students.Remove(student);
            //context.SaveChanges();
        }


    }
}



