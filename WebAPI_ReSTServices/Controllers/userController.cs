using BookMeProject;
using BusinessLogicValidationLayer;
using Castle.Windsor;
using DataAccessRepoPattern;
using DTO;
using DTOMappingLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_ReSTServices.App_Start;

namespace WebAPI_ReSTServices.Controllers
{   
    [RoutePrefix("api/bookMe/user/v1")]
    public class userController : ApiController
    {
        private usersBusinessValidation _usersBusinessValidationObj;
        private userDTOMapping _userDTOMappingObject;

        IWindsorContainer container = new IOC_BootStrapper().bootstrapContainer();


        public userController()
        {
            _usersBusinessValidationObj = new usersBusinessValidation(container.Resolve<iRepoCommand<iPoco>>(), container.Resolve<iRepoQuery<iPoco>>() );
            _userDTOMappingObject = container.Resolve<userDTOMapping>();
        }

  
        [HttpGet]
        [Route("GetAllUsers")]
        [ResponseType(typeof(List<userDTO>))]
        public IHttpActionResult getAllUsers()
        {
            try
            {
                List<userPoco> userObjList = _usersBusinessValidationObj.getAllUser();
                List<userDTO> userDTOList = _userDTOMappingObject.UserMapper().Map<List<userPoco>, List<userDTO>>(userObjList);
                if (userDTOList == null)
                {
                    return NotFound();
                }
                return Ok(userDTOList);

            } catch (Exception e)
            {
                return InternalServerError(e);
            }
            
            
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IHttpActionResult deleteUser (string id)
        {
            _usersBusinessValidationObj.deleteUser(null, null, id);
            return Ok(id);
        }


        

    }
}
