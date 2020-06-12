using BookMeProject;
using BusinessLogicValidationLayer;
using DTO;
using DTOMappingLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicServicesLayer
{
    [ServiceBehavior(MaxItemsInObjectGraph = 2147483646)]
    
    class userServicesQuery : IuserServicesQuery
    {

        usersBusinessValidation usersBusinessValidationObject;
        userDTOMapping userDTOMappingObject;

        
        public string serviceType = "query";

        public userServicesQuery()
        {
            //TODO DI OR IOC 
            usersBusinessValidationObject = new usersBusinessValidation();
            userDTOMappingObject = new userDTOMapping();

        }


        

        public bool doesUserExist(string first, string last, string email)
        {
            return usersBusinessValidationObject.doesUserExist(first, last, email);
        }

        public List<userDTO> getAllClient()
        {
            
            List<userPoco> userObjList  = usersBusinessValidationObject.getAllUser();

            //TODO DTO: Map the DTO to POCO here
            List<userDTO> userDTOList = userDTOMappingObject.UserMapper().Map< List<userPoco>,List<userDTO> >(userObjList);
            return userDTOList; 
        }

        public userDTO getClient(string emailAddress)
        {

            userPoco userPocoObject = usersBusinessValidationObject.getUser(emailAddress);

            //TODO DTO: Map the DTO to POCO here
            //userDTO userDTOObject = null;
            userDTO userDTOObject = userDTOMappingObject.UserMapper().Map<userDTO>(userPocoObject);
            return userDTOObject;


        }

        public userDTO getCompleteUserSnapshot(string emailAddress)
        {
            
            userPoco userPocoObject = usersBusinessValidationObject.getCompletUserProfile(emailAddress);
            userDTO userDTOObject = userDTOMappingObject.UserMapper().Map<userDTO>(userPocoObject);
            return userDTOObject;

        }

        public List<subscriptionsDTO> getAllUserSubscriptions(string emailAddress)
        {
            List<subscriptionsPoco> restulPocoList = usersBusinessValidationObject.getAllUserSubscriptionsPocos(emailAddress);
            List<subscriptionsDTO> subscriptionDTO = userDTOMappingObject.UserMapper().Map<List<subscriptionsPoco>, List<subscriptionsDTO>>(restulPocoList);
            return subscriptionDTO;
        }
    }
}
