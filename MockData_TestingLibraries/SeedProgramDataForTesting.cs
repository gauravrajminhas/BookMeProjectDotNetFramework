using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mock_POCO_TestingLibraries
{
    public class SeedProgramDataForTesting : BaseIOCDependencyClass
    {
        public SeedProgramDataForTesting (iRepoCommand<iPoco> IOCommandObjectReferance, iRepoQuery<iPoco> IOCQueryObjectReferance) : base(IOCommandObjectReferance, IOCQueryObjectReferance)
        {
                
        }


        public void seedProgram(int number)
        {
            programPoco[] programs= new programPoco[number];

            for(int i = 0;i< number;i++)
            {

                programs[i] = new programPoco {
                    programID = Guid.NewGuid(),
                    programDescription = "testProgram " + i,
                    capacity = i
                };


            }

            commandObjectReferance.add<programPoco>(programs);


        }

    }
}
