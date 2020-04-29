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


        public List<anotherPocoTypePlaceholder> GetAllWithProp<anotherPocoTypePlaceholder>(System.Linq.Expressions.Expression<Func<anotherPocoTypePlaceholder, iPoco>> navigationPropertyObject)
          where anotherPocoTypePlaceholder : class, iPoco
        {

            //IQueryable<anotherPocoTypePlaceholder> dbset =  _context.Set<anotherPocoTypePlaceholder>();

            return _context
                .Set<anotherPocoTypePlaceholder>()
                .Include<anotherPocoTypePlaceholder, iPoco>(navigationPropertyObject)
                .ToList<anotherPocoTypePlaceholder>();
        }


        public TypePlaceholder GetSingle(Func<TypePlaceholder, bool> where)
        {
            return _context.Set<TypePlaceholder>().FirstOrDefault(where);
        }


    }
}
