using BookMeProject;
using DataAccessEFGenericRepo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLServerEFDataAccessCommandImplementation<iPoco> commandRepo = new SQLServerEFDataAccessCommandImplementation<iPoco>();
            SQLServerEFDataAccessQueryImplementation<iPoco> queryRepo = new SQLServerEFDataAccessQueryImplementation<iPoco>();

            //seedMockData.seedMore();

            //new testClass().doSomething();

            commandRepo.add<course>(new course { courseID=Guid.NewGuid(), courseName="Entity Framework" });
            commandRepo.add<student>(new student { studentID = Guid.NewGuid(), studentName = "Test Client1" });


            student studentObject = queryRepo.GetSingle<student>(stu => stu.studentName == "Test Client1", stu => stu.courseListNavigation);
            course courseObject = queryRepo.GetSingle<course>(cou => cou.courseName == "Entity Framework");

            studentObject
                .courseListNavigation.Add(courseObject);

            course pocoCourse = new course
            {
                courseID = Guid.NewGuid(),
                courseName = "new Test course"
            };

            student poco = new student
            {
                studentID = Guid.NewGuid(),
                studentName = "new Test Student",
                courseListNavigation = new List<course>()
            };

            poco.courseListNavigation.Add(pocoCourse);

            commandRepo.add<student>(poco);


           
                
                
                
                
            //commandRepo.update<student>(studentObject);








            Console.WriteLine("\n\n\n --- Terminating --- ");
            Console.Read();
        }
    }
}
