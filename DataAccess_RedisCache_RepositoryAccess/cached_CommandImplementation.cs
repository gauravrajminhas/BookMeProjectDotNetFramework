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
    class cached_CommandImplementation<iAnotherPoco> : iRepoCommand<iPoco>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        void iRepoCommand<iPoco>.add<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosToBeAdded)
        {
            throw new NotImplementedException();
        }

        void iRepoCommand<iPoco>.delete<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosTobeDeleted)
        {
            throw new NotImplementedException();
        }

        void iRepoCommand<iPoco>.delete<anotherPocoTypePlaceholder>(Expression<Func<anotherPocoTypePlaceholder, bool>> wherePredicate)
        {
            throw new NotImplementedException();
        }

        void iRepoCommand<iPoco>.update<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosToBeUpdated)
        {
            throw new NotImplementedException();
        }
    }
}
