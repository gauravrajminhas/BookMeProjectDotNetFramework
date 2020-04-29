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
   
    public class SQLServerEFDataAccessCommandImplementation<TypePlaceholder> : iRepoCommand <TypePlaceholder>
        where TypePlaceholder : class, BookMeProject.iPoco
       
    {

        private SQLServerDBContext _context;

        public SQLServerEFDataAccessCommandImplementation()
        {
            _context = new SQLServerDBContext();
            _context.Database.Log = Console.Write;
        }

        public void add(params TypePlaceholder[] pocosToBeAdded)
        {
            foreach (TypePlaceholder poco in pocosToBeAdded)
            {
                _context.Entry<TypePlaceholder>(poco).State = System.Data.Entity.EntityState.Added;
            }
            _context.SaveChanges();
        }

        public void delete(params TypePlaceholder[] pocosToBeDeleted)
        {
            foreach(TypePlaceholder poco in pocosToBeDeleted)
            {
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
                _context.Entry<anotherPocoTypePlaceholder>(poco).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public void delete(Expression<Func<TypePlaceholder, bool>> wherePredicate)
        {
            IEnumerable<TypePlaceholder> pocosTobeDeleted = _context.Set<TypePlaceholder>().Where(wherePredicate);

            foreach (TypePlaceholder poco in pocosTobeDeleted)
            {
                _context.Entry<TypePlaceholder>(poco).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }







        public void update(params TypePlaceholder[] pocosToBeUpdated)
        {
            throw new NotImplementedException();
        }
    }
}
