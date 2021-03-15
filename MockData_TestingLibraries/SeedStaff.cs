using BookMeProject;
using BookMeProject.Staff.Schema;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Poco_seedData_mockData
{
    public class SeedStaff :BaseIOCDependencyClass, IMockDataTestingValidation
    {
        public SeedStaff(iRepoCommand<iPoco> commandRepoInjection, iRepoQuery<iPoco> queryRepoInjection) : base(commandRepoInjection, queryRepoInjection)
        {

        }

        
        public void seedMockStaffMembers(int count)
        {
            
            staffPoco[] staffmembersArray = new staffPoco[count];

            cityPoco cityPoco = queryObjectReferace.GetSingle<cityPoco>(cp => cp.cityName == "Toronto");
            statePoco statePoco = queryObjectReferace.GetSingle<statePoco>(sp => sp.stateName == "Ontario");
            countryPoco countryPoco = queryObjectReferace.GetSingle<countryPoco>(cp => cp.countryName == "Canada");


            for (int i=0; i<count; i++)
            {


                staffmembersArray[i] = new staffPoco {
                    ecifID = Guid.NewGuid(),
                    firstname = "TestStaff Firstname" + new Random().Next(), 
                    lastName = "TestStaff LastName" + new Random().Next(),
                    cityID = cityPoco.cityID,
                    stateID = statePoco.stateID,
                    countryID = countryPoco.countryID,
                    cityPocoNavigation = cityPoco,
                    statePocoNavigation = statePoco,
                    countryPocoNavigation = countryPoco

                };

                
            }


            commandObjectReferance.add<staffPoco>(staffmembersArray);

        }





    }
}
