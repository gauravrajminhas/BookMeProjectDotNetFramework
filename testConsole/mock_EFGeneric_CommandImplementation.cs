﻿using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    public class mock_EFGeneric_CommandImplementation<pocoType> : iRepoCommand<pocoType>
        where pocoType : iPoco
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        void iRepoCommand<pocoType>.add<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosToBeAdded)
        {
            throw new NotImplementedException();
        }

        void iRepoCommand<pocoType>.delete<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosTobeDeleted)
        {
            throw new NotImplementedException();
        }

        void iRepoCommand<pocoType>.delete<anotherPocoTypePlaceholder>(Expression<Func<anotherPocoTypePlaceholder, bool>> wherePredicate)
        {
            throw new NotImplementedException();
        }

        void iRepoCommand<pocoType>.update<anotherPocoTypePlaceholder>(params anotherPocoTypePlaceholder[] pocosToBeUpdated)
        {
            throw new NotImplementedException();
        }
    }
}
