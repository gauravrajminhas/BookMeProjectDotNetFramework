using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    public class mock_EFGeneric_QueryImplementation<pocoType> : iRepoQuery<pocoType>
        where pocoType : iPoco
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        List<anotherPocoTypePlaceholder> iRepoQuery<pocoType>.GetAll<anotherPocoTypePlaceholder>(params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationObjectPath)
        {
            throw new NotImplementedException();
        }

        List<anotherPocoTypePlaceholder> iRepoQuery<pocoType>.GetAll<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate, params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationObjectPath)
        {
            throw new NotImplementedException();
        }

        anotherPocoTypePlaceholder iRepoQuery<pocoType>.GetSingle<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate, params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationPropertyPathObjectList)
        {
            throw new NotImplementedException();
        }
    }
}
