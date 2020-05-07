using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMeProject;
using DataAccessRepoPattern;
using System.Data.Entity;
using System.Linq.Expressions;


namespace DataAccessEFGenericRepo
{
    public class SQLServerEFDataAccessQueryImplementation<TypePlaceholder> : iRepoQuery<TypePlaceholder>
        where TypePlaceholder : class, BookMeProject.iPoco
    {
        private SQLServerDBContext _context;

      
        public SQLServerEFDataAccessQueryImplementation()
        {
            _context = new SQLServerDBContext();
            _context.Database.Log = Console.Write;
        }


        // this has a differen generic type Coz you can use it to get any Sort of poco 
        public List<anotherPocoTypePlaceholder> GetAll<anotherPocoTypePlaceholder>()
            where anotherPocoTypePlaceholder : class, iPoco
        {
            return _context.Set<anotherPocoTypePlaceholder>().ToList<anotherPocoTypePlaceholder>();
        }


        public List<anotherPocoTypePlaceholder> GetAll<anotherPocoTypePlaceholder>(Expression<Func<anotherPocoTypePlaceholder, object>> navigationPropertyPathObject)
          where anotherPocoTypePlaceholder : class, iPoco
        {

            //IQueryable<anotherPocoTypePlaceholder> dbset =  _context.Set<anotherPocoTypePlaceholder>();
            // a labda expressing the Path  i.e  (Student => student.CourseListNavigationProperty)
            return _context
                .Set<anotherPocoTypePlaceholder>()
                .Include<anotherPocoTypePlaceholder, object>(navigationPropertyPathObject)
                .ToList<anotherPocoTypePlaceholder>();
        }

       
        public anotherPocoTypePlaceholder GetSingle<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate)
            where anotherPocoTypePlaceholder : class, iPoco
        {
            return _context.Set<anotherPocoTypePlaceholder>().FirstOrDefault(wherePredicate);
        }


        //public anotherPocoTypePlaceholder GetSingle <anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate, Expression<Func<anotherPocoTypePlaceholder, object>> navigationPropertyPathObject)
        //    where anotherPocoTypePlaceholder : class, iPoco
        //{

        //    return _context.Set<anotherPocoTypePlaceholder>()
        //        .Include<anotherPocoTypePlaceholder, object>(navigationPropertyPathObject)
        //        .FirstOrDefault(wherePredicate);
        //}

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

            //return _context.Set<anotherPocoTypePlaceholder>()
            //    .Include<anotherPocoTypePlaceholder, object>(navigationPropertyPathObject)
            //    .FirstOrDefault(wherePredicate);

            return queryBuilder.FirstOrDefault(wherePredicate);
        }



    }
}
