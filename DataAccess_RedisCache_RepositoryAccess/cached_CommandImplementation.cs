using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_RedisCache_RepositoryAccess
{
    class cached_CommandImplementation<iPocoType> : iCachedCommandRepo<iPocoType>
        where iPocoType : iPoco
    {

        private iRepoCommand<iPoco> _iRepoCommandInjection;
    
                          
        public cached_CommandImplementation( iRepoCommand<iPoco> iRepoCommandInjection )
        { 
            _iRepoCommandInjection = iRepoCommandInjection;
           
        }

        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        void iRepoCommand<iPocoType>.add<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosToBeAdded)
        {
            Console.WriteLine("Cached Repo");
            _iRepoCommandInjection.add<anotherPocoTypePlaceholder>(pocosToBeAdded);
        }

        void iRepoCommand<iPocoType>.delete<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosTobeDeleted)
        {
            Console.WriteLine("Cached Repo");
            _iRepoCommandInjection.delete<anotherPocoTypePlaceholder>(pocosTobeDeleted);
        }

        void iRepoCommand<iPocoType>.delete<anotherPocoTypePlaceholder>(Expression<Func<anotherPocoTypePlaceholder, bool>> wherePredicate)
        {
            Console.WriteLine("Cached Repo");
            _iRepoCommandInjection.delete<anotherPocoTypePlaceholder>(wherePredicate);
        }

        void iRepoCommand<iPocoType>.update<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosToBeUpdated)
        {
            Console.WriteLine("Cached Repo");
            _iRepoCommandInjection.update<anotherPocoTypePlaceholder>(pocosToBeUpdated);
        }
    }
}
