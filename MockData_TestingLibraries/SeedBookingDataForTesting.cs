using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Poco_seedData_mockData
{
    class SeedBookingDataForTesting : BaseIOCDependencyClass, IMockDataTestingValidation 
    {
        public SeedBookingDataForTesting(iRepoCommand<iPoco> IOCommandObjectReferance, iRepoQuery<iPoco> IOCQueryObjectReferance) : base(IOCommandObjectReferance, IOCQueryObjectReferance)
        {

        }

    }
}
