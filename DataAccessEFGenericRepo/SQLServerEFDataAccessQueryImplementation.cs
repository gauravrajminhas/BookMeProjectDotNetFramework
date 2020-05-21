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
            //TODO - add dependency injection IOC controller here ! 

            _context = SQLServerDBContext.SQLServerDBContextSingeltonFactory();
            _context.Database.Log = Console.Write;
        }



        public List<anotherPocoTypePlaceholder> GetAll<anotherPocoTypePlaceholder>(params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationPropertyListPathObject)
          where anotherPocoTypePlaceholder : class, iPoco
        {

            IQueryable<anotherPocoTypePlaceholder> queryBuilder = _context.Set<anotherPocoTypePlaceholder>();


            foreach (Expression <Func<anotherPocoTypePlaceholder, object>> navigationPropertyPathObject  in navigationPropertyListPathObject)
            {
                queryBuilder = queryBuilder
                    .Include<anotherPocoTypePlaceholder, object>(navigationPropertyPathObject);
            }
         
            List<anotherPocoTypePlaceholder> pocoList = queryBuilder.ToList<anotherPocoTypePlaceholder>();



            if (pocoList == null)
            {
                return null;
            }
            else
            {
                // to see the DBContext tracking state of Poco 
                foreach (anotherPocoTypePlaceholder poco in pocoList){
                    Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n" + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
                }

                return pocoList;
            }
        }

        public anotherPocoTypePlaceholder GetSingle<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate, params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationPropertyPathObjectList)
            where anotherPocoTypePlaceholder : class, iPoco
        {

            IQueryable<anotherPocoTypePlaceholder> queryBuilder = null;


            //trial 
            _context.Configuration.LazyLoadingEnabled = false;

            DbSet<anotherPocoTypePlaceholder> dbSet = _context.Set<anotherPocoTypePlaceholder>();

            queryBuilder = dbSet;
            foreach (Expression<Func<anotherPocoTypePlaceholder, object>> navigationPropertyPathObject in navigationPropertyPathObjectList)
            {
                queryBuilder = queryBuilder.Include<anotherPocoTypePlaceholder, object>(navigationPropertyPathObject);
            }

            anotherPocoTypePlaceholder poco = queryBuilder
           //     .AsNoTracking()
                .FirstOrDefault(wherePredicate);

            if (poco == null)
            {
                return null; 
            }
            else
            {
                Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n" + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
                return poco;
            }
            
        }


    }
}






//-----Defunked Code -------

//// this has a differen generic type Coz you can use it to get any Sort of poco 
//public List<anotherPocoTypePlaceholder> GetAll<anotherPocoTypePlaceholder>()
//    where anotherPocoTypePlaceholder : class, iPoco
//{
//    List<anotherPocoTypePlaceholder> pocoList = _context.Set<anotherPocoTypePlaceholder>()
////        .AsNoTracking()
//        .ToList<anotherPocoTypePlaceholder>();

//    foreach (anotherPocoTypePlaceholder poco in pocoList)
//    {
//        Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n" + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
//    }


//    return pocoList;
//}


//public anotherPocoTypePlaceholder GetSingle<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate)
//    where anotherPocoTypePlaceholder : class, iPoco
//{
//    anotherPocoTypePlaceholder poco = _context.Set<anotherPocoTypePlaceholder>()
// //       .AsNoTracking()
//        .FirstOrDefault(wherePredicate);

//    Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n" + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
//    return poco;
//}
