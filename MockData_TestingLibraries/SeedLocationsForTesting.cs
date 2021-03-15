using BookMeProject;
using DataAccessRepoPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Poco_seedData_mockData
{
    public class  SeedLocationsForTesting : BaseIOCDependencyClass
    {
        public SeedLocationsForTesting (iRepoCommand<iPoco> IOCommandObjectReferance, iRepoQuery<iPoco> IOCQueryObjectReferance) :base(IOCommandObjectReferance, IOCQueryObjectReferance)
        {
                                                        
        }



        public void seedLocationData()
        {
            // populating the Referance Datas tables 
           

            if (queryObjectReferace.GetSingle<countryPoco>(cp => cp.countryName =="India" ) == null)
            {
                commandObjectReferance.add<countryPoco>(new countryPoco
                {
                    countryID = Guid.NewGuid(),
                    countryName = "India"
                });
            }
            if (queryObjectReferace.GetSingle<statePoco>(sp => sp.stateName == "Maharashtra") == null )
            {
                commandObjectReferance.add<statePoco>(new statePoco
                {
                    stateID = Guid.NewGuid(),
                    stateName = "Maharashtra"
                });
            }
            if (queryObjectReferace.GetSingle<cityPoco>(cp => cp.cityName== "Bombay") == null)
            {
                commandObjectReferance.add<cityPoco>(new cityPoco
                {
                    cityID = Guid.NewGuid(),
                    cityName = "Bombay"
                });
            }



            if (queryObjectReferace.GetSingle<cityPoco>( cp=> cp.cityName == "Toronto") ==null)
            {
                commandObjectReferance.add<cityPoco>( new cityPoco
                {
                    cityID = Guid.NewGuid(),
                    cityName = "Toronto"
                });
            }


            if (queryObjectReferace.GetSingle<statePoco>( sp=>sp.stateName == "Ontario") == null)
            {
                commandObjectReferance.add<statePoco>( new statePoco
                {
                    stateID = Guid.NewGuid(),
                    stateName = "Ontario"
                });

            }

            if (queryObjectReferace.GetSingle<countryPoco>( cp => cp.countryName== "Canada") == null)
            {
                commandObjectReferance.add<countryPoco>( new countryPoco
                {
                    countryID = Guid.NewGuid(),
                    countryName = "Canada",
                });

            }

            




        }

    }
}
