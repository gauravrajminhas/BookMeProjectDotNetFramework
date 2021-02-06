using System;
using System.Collections.Generic;
using System.Text;
using DataAccessRepoPattern;
using BookMeProject;

namespace Test_Poco_seedData_mockData
{
    class SeedClassDataForTesting : BaseIOCDependencyClass, IMockDataTestingValidation
    {
       
        public SeedClassDataForTesting(iRepoCommand<iPoco> IOCommandObjectReferance, iRepoQuery<iPoco> IOCQueryObjectReferance) : base(IOCommandObjectReferance, IOCQueryObjectReferance)
        {

        }

        
        public void seedProgramData()
        {
            programPoco tetProgramObject = new programPoco()
            {
                programID = Guid.NewGuid(),
                programDescription = "CrossFit"
                
            };

            

        }
        
       



    }
}
