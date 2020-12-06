using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicValidationLayer
{
    class subscriptionsBusinessValidation : IbusinessValidation
    {
        iRepoCommand<iPoco> commandObject;
        iRepoQuery<iPoco> queryObject;
        public subscriptionsBusinessValidation(iRepoCommand<iPoco> commandObjectInjection, iRepoQuery<iPoco> queryObjectInjection)
        {
            commandObject = commandObjectInjection;
            queryObject = queryObjectInjection;
        }
    }
}
