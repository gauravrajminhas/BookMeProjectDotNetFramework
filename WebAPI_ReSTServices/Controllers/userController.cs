﻿using BookMeProject;
using BusinessLogicValidationLayer;
using Castle.Windsor;
using DataAccessRepoPattern;
using DTO;
using DTOMappingLayer;
using System;
using System.CodeDom;
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
        private userCRUDValidation _userCRUDValidationObj;
        private userDTOMapping _userDTOMappingObject;

        IWindsorContainer container = new IOC_BootStrapper().bootstrapContainer();


        public userController()
        {
            _userCRUDValidationObj = new userCRUDValidation(container.Resolve<iCachedCommandRepo<iPoco>>(), container.Resolve<iCachedQueryRepo<iPoco>>(), container.Resolve<userDTOMapping>());
            _userDTOMappingObject = container.Resolve<userDTOMapping>();
        }


        [HttpGet]
        [Route("GetAllUsers")]
        [ResponseType(typeof(List<userDTO>))]
        public IHttpActionResult getAllUsers()
        {
                List<userDTO> userDTOList = _userCRUDValidationObj.getAllUserDTOs();
                //List<userDTO> userDTOList = _userDTOMappingObject.UserMapper().Map<List<userPoco>, List<userDTO>>(userObjList);
                if (userDTOList == null)
                {
                    return NotFound();
                }
                return Ok(userDTOList);

            //} catch (Exception e)
            //{
            //    return InternalServerError(e);
            //}


        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IHttpActionResult deleteUser(string id)
        {
            _userCRUDValidationObj.deleteUser(null, null, id);
            return Ok(id);
        }


        [HttpGet]
        [Route("GetSingleUser")]
        [ResponseType(typeof(userDTO))]
        public IHttpActionResult GetSingleUser([FromUri] string emailAddress)
        {
            userDTO result = _userCRUDValidationObj.getUserDTO(emailAddress);

            return Ok(result);
        }


        [HttpPost]
        [Route("addUser")]
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult addUser([FromBody] string first, string last, string emailID)
        {
            _userCRUDValidationObj.addUser(first, last, emailID);

            return Ok();
        }


        [HttpGet]
        [Route("getCompleteUserProfile")]
        [ResponseType(typeof(userDTO))]
        public userDTO getCompleteUserProfile([FromUri] string emailID)
        {
            return _userCRUDValidationObj.getCompletUserDTOProfile(emailID);
        }



    }
}
