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
   
    public class SQLServerEFDataAccessCommandImplementation<TypePlaceholder> : iRepoCommand <TypePlaceholder>
        where TypePlaceholder : class, BookMeProject.iPoco
       
    {

        private SQLServerDBContext _context;

        public SQLServerEFDataAccessCommandImplementation()
        {
            // DI IOC container will come here 
            //_context = SQLServerDBContext.SQLServerDBContextSingeltonFactory();
            _context = SQLServerDBContext.SQLServerDBContextNonSingeltonFactory();

            _context.Database.Log = Console.Write;
        }

        public void add<TypePlaceholder>(params TypePlaceholder[] pocosToBeAdded)
            where TypePlaceholder : class, BookMeProject.iPoco

        {
            foreach (TypePlaceholder poco in pocosToBeAdded)
            {
                Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n" + _context.Entry<TypePlaceholder>(poco).State);
                _context.Entry<TypePlaceholder>(poco).State = System.Data.Entity.EntityState.Added;
            }
            _context.SaveChanges();
        }

        public void delete<TypePlaceholder> (params TypePlaceholder[] pocosToBeDeleted)
            where TypePlaceholder : class, BookMeProject.iPoco
        {
            foreach(TypePlaceholder poco in pocosToBeDeleted)
            {
                Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n" + _context.Entry<TypePlaceholder>(poco).State);
                _context.Entry<TypePlaceholder>(poco).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }


        // this will not work for entities with navigation Properties. 
        // FIx this 
        public void delete<anotherPocoTypePlaceholder> (Expression <Func<anotherPocoTypePlaceholder, bool>> wherePredicate)
            where anotherPocoTypePlaceholder : class, iPoco
        {
            IEnumerable<anotherPocoTypePlaceholder> pocosTobeDeleted = _context.Set<anotherPocoTypePlaceholder>().Where(wherePredicate);

            foreach (anotherPocoTypePlaceholder poco in pocosTobeDeleted)
            {
                Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n" + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
                _context.Entry<anotherPocoTypePlaceholder>(poco).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

       
        public void update<TypePlaceholder>(params TypePlaceholder[] pocosToBeUpdated)
            where TypePlaceholder : class, BookMeProject.iPoco
        {
            //SQLServerDBContext _updateContext = null;

            //doubt :-  Should this be per CRUD method or per request ? 
            //using(_updateContext= new SQLServerDBContext())
            //{
                foreach (TypePlaceholder poco in pocosToBeUpdated)
                {


                    Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n"+ _context.Entry<TypePlaceholder>(poco).State);
                    _context.Entry<TypePlaceholder>(poco).State = EntityState.Added;

                    foreach (var entity in _context.ChangeTracker.Entries())
                    {
                        Console.WriteLine("{0}: {1}", entity.Entity.GetType().Name, entity.State);
                    }


                _context.Entry<TypePlaceholder>(poco).State = EntityState.Modified;
                }
                _context.SaveChanges();

            //}
            
        }
    }
}
