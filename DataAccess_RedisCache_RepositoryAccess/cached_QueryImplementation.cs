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
    class cached_QueryImplementation<iAnotherPocotype> : iRepoQuery<iPoco>
    {
        public cached_QueryImplementation()
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        List<anotherPocoTypePlaceholder> iRepoQuery<iPoco>.GetAll<anotherPocoTypePlaceholder>(params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationObjectPath)
        {
            throw new NotImplementedException();
        }

        List<anotherPocoTypePlaceholder> iRepoQuery<iPoco>.GetAll<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate, params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationObjectPath)
        {
            throw new NotImplementedException();
        }

        anotherPocoTypePlaceholder iRepoQuery<iPoco>.GetSingle<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate, params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationPropertyPathObjectList)
        {
            throw new NotImplementedException();
        }
    }
}
