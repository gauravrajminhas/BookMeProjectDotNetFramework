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
   
    public class EFGeneric_CommandImplementation<TypePlaceholder> : iRepoCommand <TypePlaceholder>
        where TypePlaceholder : class, BookMeProject.iPoco
       
    {

        private bookMeDBContext _context;

        public EFGeneric_CommandImplementation (bookMeDBContext dbContextInjection)
        {

            _context = dbContextInjection;
            _context.Database.Log = Console.Write;

            // DI IOC container will come here 
            //_context = bookMeDBContext.bookMeDBContextSingeltonFactory();
            //_context = bookMeDBContext.bookMeDBContextNonSingeltonFactory();


        }

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
                    Console.WriteLine(e.Message);
                    dbTransaction.Rollback();
                }

                dbTransaction.Commit();
            }
         
        }
    
        public void delete<anotherPocoTypePlaceholder> (params anotherPocoTypePlaceholder[] pocosToBeDeleted)
            where anotherPocoTypePlaceholder : class, BookMeProject.iPoco
        {
            
                foreach (anotherPocoTypePlaceholder poco in pocosToBeDeleted)
                {
                    if (poco != null)
                    {
                        //Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n" + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
                        _context.Entry<anotherPocoTypePlaceholder>(poco).State = EntityState.Deleted;
                    }
                    else{
                        throw new Exception("EF Implementation Layer:- A Null Record was Found");
                    }
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
                if (poco != null)
                {
                    Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n" + _context.Entry<anotherPocoTypePlaceholder>(poco).State);
                    _context.Entry<anotherPocoTypePlaceholder>(poco).State = EntityState.Deleted;
                }
                else {
                    throw new Exception("EF Implementation Layer:- A Null Record was Found");
                }

            }
            _context.SaveChanges();
        }

       
        public void Dispose()
        {
            _context.Dispose();
        }

        public void update<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosToBeUpdated)
            where anotherPocoTypePlaceholder : class, BookMeProject.iPoco
        {
            
            //doubt :-  Should this be per CRUD method or per request ? 
            //using(_updateContext= new bookMeDBContext())
            foreach (anotherPocoTypePlaceholder poco in pocosToBeUpdated)
                {


                    Console.WriteLine("\n\n\n current state of the Poco :- \n\n\n"+ _context.Entry<anotherPocoTypePlaceholder>(poco).State);
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
                }catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    dbTransaction.Rollback();
                }

                dbTransaction.Commit();

            } 
            
        }
    }
}
