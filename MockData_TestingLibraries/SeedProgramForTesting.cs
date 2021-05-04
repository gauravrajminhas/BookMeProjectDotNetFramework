using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Poco_seedData_mockData
{
    public class SeedProgramForTesting : BaseIOCDependencyClass
    {
        public SeedProgramForTesting(iRepoCommand<iPoco> IOCommandObjectReferance, iRepoQuery<iPoco> IOCQueryObjectReferance) : base(IOCommandObjectReferance, IOCQueryObjectReferance)
        {

        }


        public void seedProgram()
        {


            if (queryObjectReferace.GetSingle<programPoco>(pp => pp.programDescription == "crossfit") == null && queryObjectReferace.GetSingle<programPoco>(pp => pp.programDescription == "OlympicLifting") == null)
            {
                commandObjectReferance.add<programPoco>(
                new programPoco
                {
                    programID = Guid.NewGuid(),
                    programDescription = "crossfit"
                },
                new programPoco
                {
                    programID = Guid.NewGuid(),
                    programDescription = "OlympicLifting"
                }

                );
            }


        }


        public void seedProgram(int number)
        {
            programPoco[] programs = new programPoco[number];

            for (int i = 0; i < number; i++)
            {

                programs[i] = new programPoco
                {
                    programID = Guid.NewGuid(),
                    programDescription = "testProgram " + i,
                    capacity = i
                };


            }

            commandObjectReferance.add<programPoco>(programs);


        }



    }
}
