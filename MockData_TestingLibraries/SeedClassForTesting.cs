using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Poco_seedData_mockData
{
    public class SeedClassForTesting : BaseIOCDependencyClass, IMockDataTestingValidation
    {
        public SeedClassForTesting (iRepoCommand<iPoco> IOCommandObjectReferance, iRepoQuery<iPoco> IOCQueryObjectReferance) : base (IOCommandObjectReferance, IOCQueryObjectReferance)
        {

        }


        public void seedClass()
        {

            programPoco crossfitPoco = queryObjectReferace.GetSingle<programPoco>(pp => pp.programDescription == "crossfit");
            if (crossfitPoco == null)
            {
                new SeedProgramForTesting(commandObjectReferance,queryObjectReferace).seedProgram();
            }

            programPoco crossfitProgram = queryObjectReferace.GetSingle<programPoco>(pp=>pp.programDescription=="crossfit");


            commandObjectReferance.add<classPoco>(
                new classPoco{
                    classID=Guid.NewGuid(),
                    programID = crossfitProgram.programID,


                }

                );
           
            
        }





    }
}
