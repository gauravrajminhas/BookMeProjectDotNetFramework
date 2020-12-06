using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mock_POCO_TestingLibraries
{
    public class BaseIOCDependencyClass : IMockDataTestingValidation
    {
        protected iRepoCommand<iPoco> commandObjectReferance;
        protected iRepoQuery<iPoco> queryObjectReferace;

       public BaseIOCDependencyClass (iRepoCommand<iPoco> IOCommandObjectReferance, iRepoQuery<iPoco> IOCQueryObjectReferance)
        {
            commandObjectReferance = IOCommandObjectReferance;
            queryObjectReferace = IOCQueryObjectReferance;

        }
    }
}
