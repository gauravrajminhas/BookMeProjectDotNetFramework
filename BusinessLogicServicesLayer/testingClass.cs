using BookMeProject;
using BusinessLogicValidationLayer;
using Castle.Windsor;
using DataAccessRepoPattern;
using FaultsAndExceptions;
using System.Collections.Generic;
using System.ServiceModel;
using WebAPI_ReSTServices.App_Start;
using Test_Poco_seedData_mockData;

namespace BusinessLogicServicesLayer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class testingClass : iTest
    {
        private List<string> _stringList = new List<string>();
        IWindsorContainer container = new IOC_BootStrapper().bootstrapContainer();



        public testingClass()
        {
            
        }
        
        public void add(string text)
        {
            _stringList.Add(text);
        }

        public string get(int position)
        {
            return _stringList[position];
        }

        public void testException()
        {

            throw new FaultException<missingUserEmailDetails>(new missingUserEmailDetails {
                errorCode = 1,
                errorMsg = "missingUserEmailDetails:- check with your local Administrator"

            } , "missingUserEmailDetails:- check with your local Administrator"); 
            
        }

        public void testNoClientfoundException()
        {
            throw new FaultException<noClientFoundException>(new noClientFoundException
            {
                errorCode = 1,
                errorMsg = "noClientFoundException:- check with your local Administrator"
            }, "noClientFoundException:- check with your local Administrator");
        }




        public void seedTestData()
        {
            new SeedProgramDataForTesting(container.Resolve<iRepoCommand<iPoco>>(), container.Resolve<iRepoQuery<iPoco>>()).seedProgram(10);
            new SeedUserDataForTesting (container.Resolve<iRepoCommand<iPoco>>(), container.Resolve<iRepoQuery<iPoco>>()).seedData();

        }

    }
}
