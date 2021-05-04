using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_Poco_seedData_mockData
{
    class SeedBookingDataForTesting : BaseIOCDependencyClass, IMockDataTestingValidation 
    {
        public SeedBookingDataForTesting(iRepoCommand<iPoco> IOCommandObjectReferance, iRepoQuery<iPoco> IOCQueryObjectReferance) : base(IOCommandObjectReferance, IOCQueryObjectReferance)
        {

        }
        public void seedBooking()
        {
            userPoco TestUserWithCredentails = queryObjectReferace.GetSingle<userPoco>(up => up.emailAddress== "completeUser1@qa.com", up=>up.userCredentialsListNavigation);
            programPoco TestProgramWithClassList = queryObjectReferace.GetSingle<programPoco>(pp=> pp.programDescription=="crossfit", pp=>pp.classesListNavigation);

            
            if (TestUserWithCredentails == null || TestProgramWithClassList.classesListNavigation==null)
            {
                new SeedProgramForTesting(commandObjectReferance, queryObjectReferace).seedProgram();
                new SeedClassForTesting(commandObjectReferance, queryObjectReferace).seedClass();

            }

            TestUserWithCredentails = queryObjectReferace.GetSingle<userPoco>(up => up.emailAddress == "completeUser1@qa.com", up => up.userCredentialsListNavigation);
            TestProgramWithClassList = queryObjectReferace.GetSingle<programPoco>(pp => pp.programDescription == "crossfit", pp => pp.classesListNavigation);

            bookingPoco testBookingPoco = new bookingPoco {
                bookingID = Guid.NewGuid(),
                classID = TestProgramWithClassList.classesListNavigation.FirstOrDefault<classPoco>().classID,
                UserID = TestUserWithCredentails.userCredentialsListNavigation.FirstOrDefault<userCredentialsPoco>().userID,
                isWaitlisted = false
            };







        }
    }
}
