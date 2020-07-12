using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFGenericRepo
{
    public class EFGeneric_multiDBProvider_RepositoryImplementation<TypePlaceholder> : iRepo<TypePlaceholder> 
        where TypePlaceholder : class, iPoco
    {


        //Ineed to use the context.database.BeginTransaction and thus public 
        private bookMeDBContext _context;

        public EFGeneric_multiDBProvider_RepositoryImplementation()
        {
            // DI IOC container will come here 
            _context = new bookMeDBContext();
            //_context = bookMeDBContext.bookMeDBContextNonSingeltonFactory();

            _context.Database.Log = Console.Write;
        }


        // ---------------------------------------------- Support for multi-db Provider ----------------------------------------------------------------






        // ----------------------------------------- return a dbContext Instance for transaction support-----------------------------------------------------------

        public bookMeDBContext getDBContext()
        {
            if (_context != null)
                return _context;
            else
                throw new Exception("Context is null. Please Investigate");
            
        }



        // ---------------------------------------------- EF Generic Command Methods ----------------------------------------------------------------

        public void add<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosToBeAdded)
            where anotherPocoTypePlaceholder : class, BookMeProject.iPoco

        {
            foreach (anotherPocoTypePlaceholder poco in pocosToBeAdded)
            {
                Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n" + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
                _context.Entry<anotherPocoTypePlaceholder>(poco).State = System.Data.Entity.EntityState.Added;
            }


            // Trying a Transaction Code here
            using (DbContextTransaction dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    dbTransaction.Rollback();
                }

                dbTransaction.Commit();
            }

        }
        public void delete<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosToBeDeleted)
            where anotherPocoTypePlaceholder : class, BookMeProject.iPoco
        {
            foreach (anotherPocoTypePlaceholder poco in pocosToBeDeleted)
            {
                Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n" + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
                _context.Entry<anotherPocoTypePlaceholder>(poco).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }
        // This will not work for entities with navigation Properties. -- FIX this 
        public void delete<anotherPocoTypePlaceholder>(Expression<Func<anotherPocoTypePlaceholder, bool>> wherePredicate)
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
        public void update<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosToBeUpdated)
            where anotherPocoTypePlaceholder : class, BookMeProject.iPoco
        {

            //doubt :-  Should this be per CRUD method or per request ? 
            //using(_updateContext= new bookMeDBContext())
            foreach (anotherPocoTypePlaceholder poco in pocosToBeUpdated)
            {


                Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n" + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
                _context.Entry<anotherPocoTypePlaceholder>(poco).State = EntityState.Added;

                foreach (var entity in _context.ChangeTracker.Entries())
                {
                    Console.WriteLine("{0}: {1}", entity.Entity.GetType().Name, entity.State);
                }


                _context.Entry<anotherPocoTypePlaceholder>(poco).State = EntityState.Modified;
            }

            // Trying a Transaction Code here
            using (var dbTransaction = _context.Database.BeginTransaction())
            {

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    dbTransaction.Rollback();
                }

                dbTransaction.Commit();

            }

        }

        
        
        
        
        
        // ---------------------------------------------- EF Generic Query Methods ----------------------------------------------------------------

        // This returns the Pocos with all its navigation Properties ----> without a predicate or a Select criterion
        public List<anotherPocoTypePlaceholder> GetAll<anotherPocoTypePlaceholder>(params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationPropertyListPathObject)
          where anotherPocoTypePlaceholder : class, iPoco
        {


            IQueryable<anotherPocoTypePlaceholder> queryBuilder = _context.Set<anotherPocoTypePlaceholder>();

            foreach (Expression<Func<anotherPocoTypePlaceholder, object>> navigationPropertyPathObject in navigationPropertyListPathObject)
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
                foreach (anotherPocoTypePlaceholder poco in pocoList)
                {
                    Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n" + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
                }

                return pocoList;
            }


        }
        // This returns the Pocos with all its navigation Properties ----> with a predicate or a Selection Criterion
        public List<anotherPocoTypePlaceholder> GetAll<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate, params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationPropertyListPathObject)
          where anotherPocoTypePlaceholder : class, iPoco
        {

            IQueryable<anotherPocoTypePlaceholder> queryBuilder = _context.Set<anotherPocoTypePlaceholder>();


            foreach (Expression<Func<anotherPocoTypePlaceholder, object>> navigationPropertyPathObject in navigationPropertyListPathObject)
            {
                queryBuilder = queryBuilder
                    .Include<anotherPocoTypePlaceholder, object>(navigationPropertyPathObject);
            }

            List<anotherPocoTypePlaceholder> pocoList = queryBuilder
                .Where<anotherPocoTypePlaceholder>(wherePredicate)
                .ToList<anotherPocoTypePlaceholder>();



            if (pocoList == null)
            {
                return null;
            }
            else
            {
                // to see the DBContext tracking state of Poco 
                foreach (anotherPocoTypePlaceholder poco in pocoList)
                {
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




        
        // ---------------------------------------------- DB Context Lifecycle --------------------------------------------------------------------

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
