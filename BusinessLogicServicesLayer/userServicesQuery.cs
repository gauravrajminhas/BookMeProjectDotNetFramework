using BookMeProject;
using BusinessLogicValidationLayer;
using Castle.Windsor;
using DataAccessRepoPattern;
using DTO;
using DTOMappingLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebAPI_ReSTServices.App_Start;

namespace BusinessLogicServicesLayer
{
    [ServiceBehavior(MaxItemsInObjectGraph = 2147483646)]
    
    public class userServicesQuery : IuserServicesQuery
    {

        userCRUDValidation userCRUDValidationObject;
        userDTOMapping userDTOMappingObject;
        IWindsorContainer container = new IOC_BootStrapper().bootstrapContainer();
  
        public string serviceType = "query";

        public userServicesQuery()
        {
            //TODO DI OR IOC 
            userCRUDValidationObject = new userCRUDValidation(container.Resolve<iRepoCommand<iPoco>>(), container.Resolve<iRepoQuery<iPoco>>(), container.Resolve<userDTOMapping>());
            userDTOMappingObject = new userDTOMapping();

        }


        public bool doesUserExist(string first, string last, string email)
        {
            return userCRUDValidationObject.doesUserExist(first, last, email);
        }

        public List<userDTO> getAllClient()
        {      
            List<userDTO> userDTOList  = userCRUDValidationObject.getAllUserDTOs();
            //TODO DTO: Map the DTO to POCO here
            //List<userDTO> userDTOList = userDTOMappingObject.UserMapper().Map< List<userPoco>,List<userDTO> >(userObjList);
            return userDTOList; 
        }

        public userDTO getUser(string emailAddress)
        {

            userDTO resultDTO = userCRUDValidationObject.getUserDTO(emailAddress);

            //TODO DTO: Map the DTO to POCO here
            //userDTO userDTOObject = null;
            //userDTO userDTOObject = userDTOMappingObject.UserMapper().Map<userDTO>(userPocoObject);
            return resultDTO;


        }

        public userDTO getCompleteUserSnapshot(string emailAddress)
        {
            
            userPoco userPocoObject = userCRUDValidationObject.getCompletUserProfile(emailAddress);
            userDTO userDTOObject = userDTOMappingObject.UserMapper().Map<userDTO>(userPocoObject);
            return userDTOObject;

        }

        public List<subscriptionsDTO> getAllUserSubscriptions(string emailAddress)
        {
            List<subscriptionsPoco> restulPocoList = userCRUDValidationObject.getAllUserSubscriptionsPocos(emailAddress);
            List<subscriptionsDTO> subscriptionDTO = userDTOMappingObject.UserMapper().Map<List<subscriptionsPoco>, List<subscriptionsDTO>>(restulPocoList);
            return subscriptionDTO;
        }
    }
}
