using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMeProject;
using DataAccessRepoPattern;
using System.Data.Entity;
using System.Linq.Expressions;

/// <summary>
/// Bug 1 :- this appraoch has introduced a new issue 
/// Child objects are not being saved as they are retirived by QueryDBContext and saved by commandDBContext 
/// https://stackoverflow.com/questions/18054798/entity-framework-not-saving-modified-children
/// </summary>




namespace DataAccessEFGenericRepo
{
    public class SQLServerEFDataAccessQueryImplementation<TypePlaceholder> : iRepoQuery<TypePlaceholder>
        where TypePlaceholder : class, BookMeProject.iPoco
    {
        private SQLServerDBContext _context;

      
        public SQLServerEFDataAccessQueryImplementation()
        {
            // TODO - add dependency injection IOC controller here ! 

            _context = SQLServerDBContext.SQLServerDBContextSingeltonFactory();
            _context.Database.Log = Console.Write;
        }


        // this has a differen generic type Coz you can use it to get any Sort of poco 
        public List<anotherPocoTypePlaceholder> GetAll<anotherPocoTypePlaceholder>()
            where anotherPocoTypePlaceholder : class, iPoco
        {
            List<anotherPocoTypePlaceholder> pocoList = _context.Set<anotherPocoTypePlaceholder>()
        //        .AsNoTracking()
                .ToList<anotherPocoTypePlaceholder>();

            foreach (anotherPocoTypePlaceholder poco in pocoList)
            {
                Console.WriteLine("current state of the Poco :- " + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
            }
            

            return pocoList;
        }


        public List<anotherPocoTypePlaceholder> GetAll<anotherPocoTypePlaceholder>(Expression<Func<anotherPocoTypePlaceholder, object>> navigationPropertyPathObject)
          where anotherPocoTypePlaceholder : class, iPoco
        {

            //IQueryable<anotherPocoTypePlaceholder> dbset =  _context.Set<anotherPocoTypePlaceholder>();
            // a labda expressing the Path  i.e  (Student => student.CourseListNavigationProperty)
            List<anotherPocoTypePlaceholder> pocoList = _context
                .Set<anotherPocoTypePlaceholder>()
                .Include<anotherPocoTypePlaceholder, object>(navigationPropertyPathObject)
         //       .AsNoTracking()
                .ToList<anotherPocoTypePlaceholder>();


            foreach (anotherPocoTypePlaceholder poco in pocoList)
            {
                Console.WriteLine("current state of the Poco :- " + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
            }


            return pocoList;

        }

       
        public anotherPocoTypePlaceholder GetSingle<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate)
            where anotherPocoTypePlaceholder : class, iPoco
        {
            anotherPocoTypePlaceholder poco = _context.Set<anotherPocoTypePlaceholder>()
         //       .AsNoTracking()
                .FirstOrDefault(wherePredicate);

            Console.WriteLine("current state of the Poco :- " + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
            return poco;
        }


        public anotherPocoTypePlaceholder GetSingle<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate, params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationPropertyPathObjectList)
            where anotherPocoTypePlaceholder : class, iPoco
        {

            IQueryable<anotherPocoTypePlaceholder> queryBuilder = null; 
            DbSet<anotherPocoTypePlaceholder> dbSet = _context.Set<anotherPocoTypePlaceholder>();

            queryBuilder = dbSet;
            foreach (Expression<Func<anotherPocoTypePlaceholder, object>> navigationPropertyPathObject in navigationPropertyPathObjectList)
            {
                queryBuilder = queryBuilder.Include<anotherPocoTypePlaceholder, object>(navigationPropertyPathObject);
            }

            anotherPocoTypePlaceholder poco = queryBuilder
           //     .AsNoTracking()
                .FirstOrDefault(wherePredicate);

            Console.WriteLine("current state of the Poco :- " + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
            return poco;
        }



    }
}
