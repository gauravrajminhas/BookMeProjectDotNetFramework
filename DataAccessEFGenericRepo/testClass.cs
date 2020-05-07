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
            SQLServerEFDataAccessQueryImplementation<iPoco> queryObject = new SQLServerEFDataAccessQueryImplementation<iPoco>();
            SQLServerEFDataAccessQueryImplementation<iPoco> queryGenricObject = new SQLServerEFDataAccessQueryImplementation<iPoco>();
            SQLServerDBContext testContext = new SQLServerDBContext();

            
            

            System.Console.WriteLine();
           
        }
    }
}
