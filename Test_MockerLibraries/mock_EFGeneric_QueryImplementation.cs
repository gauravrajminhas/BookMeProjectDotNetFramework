﻿using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test_MockerLibraries
{
    public class mock_EFGeneric_QueryImplementation<pocoType> : iRepoQuery<pocoType>
        where pocoType : iPoco
    {
        public void Dispose()
        {
            throw new NotImplementedException("service under maintenance");
        }

        List<anotherPocoTypePlaceholder> iRepoQuery<pocoType>.GetAll<anotherPocoTypePlaceholder>(params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationObjectPath)
        {
            throw new NotImplementedException("service under maintenance");
        }

        List<anotherPocoTypePlaceholder> iRepoQuery<pocoType>.GetAll<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate, params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationObjectPath)
        {
            throw new NotImplementedException("service under maintenance");
        }

        anotherPocoTypePlaceholder iRepoQuery<pocoType>.GetSingle<anotherPocoTypePlaceholder>(Func<anotherPocoTypePlaceholder, bool> wherePredicate, params Expression<Func<anotherPocoTypePlaceholder, object>>[] navigationPropertyPathObjectList)
        {
            throw new NotImplementedException("service under maintenance");
        }
    }
}
