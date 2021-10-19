using BookMeProject;
using DataAccessRepoPattern;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess_RedisCache_RepositoryAccess
{
    class cached_QueryImplementation<iPocoType> : iCachedQueryRepo<iPocoType>
        where iPocoType : iPoco
    {

        private iRepoQuery<iPocoType> _iRepoQueryInjection;

        //conver to the IOC controller 

        

        public cached_QueryImplementation( iRepoQuery<iPocoType> iRepoQueryInjection)
        {
            _iRepoQueryInjection = iRepoQueryInjection;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        List<anotherPocoTypePlaceholder> iRepoQuery<iPocoType>.GetAll<anotherPocoTypePlaceholder>(params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationObjectPath)
        {

            ConnectionMultiplexer  cacheConnection = redisConnectionHelper.connection;
            
            return _iRepoQueryInjection.GetAll<anotherPocoTypePlaceholder>(navigationObjectPath);
        }

        List<anotherPocoTypePlaceholder> iRepoQuery<iPocoType>.GetAll<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate, params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationObjectPath)
        {
            return _iRepoQueryInjection.GetAll<anotherPocoTypePlaceholder>(wherePredicate, navigationObjectPath);
        }

        anotherPocoTypePlaceholder iRepoQuery<iPocoType>.GetSingle<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate, params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationPropertyPathObjectList)
        {
            return _iRepoQueryInjection.GetSingle<anotherPocoTypePlaceholder>(wherePredicate, navigationPropertyPathObjectList);
        }
    }
}
