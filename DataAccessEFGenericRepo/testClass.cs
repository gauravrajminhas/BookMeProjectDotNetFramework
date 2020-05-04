using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMeProject;
using DataAccessRepoPattern;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace DataAccessEFGenericRepo
{
    public class testClass
    {


        public void doSomething()
        {
            SQLServerEFDataAccessQueryImplementation<student> queryObject = new SQLServerEFDataAccessQueryImplementation<student>();
            SQLServerEFDataAccessQueryImplementation<iPoco> queryGenricObject = new SQLServerEFDataAccessQueryImplementation<iPoco>();


            SQLServerDBContext testContext = new SQLServerDBContext();

            


            List<student> studentResult =  queryObject.GetAll<student>(stu => stu.courseListNavigation);

            foreach (student s in studentResult)
            {
                foreach (course c in s.courseListNavigation)
                {
                    System.Console.WriteLine(s.studentName+ "\t -> \t" +c.courseName);
                }
            }


            DbSet<student> students =  testContext.Set<student>();
            
            course courseToBeAdded = testContext.Set<course>().FirstOrDefault(c => c.courseName == "react");

            testContext.Set<student>()
                .Include("courseListNavigation")
                .FirstOrDefault(s => s.studentName == "gaurav")
                .courseListNavigation
                .Add(courseToBeAdded);

            var result = testContext.Set<student>()
                .Include("courseListNavigation")
                .Select(s => new { studentName = s.studentName, courseList = s.courseListNavigation.ToList() });


            foreach (var r in result)
            {
               
                foreach (var c in r.courseList)
                {
                    System.Console.WriteLine(r.studentName +"\t\t -"+ c.courseName);
                }
            }

            System.Console.WriteLine();
           
        }
    }
}
