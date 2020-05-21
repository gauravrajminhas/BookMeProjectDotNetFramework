using AutoMapper;
using BookMeProject;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOMappingLogic
{
    public class userDTOMapping :baseLogic
    {
        public Mapper UserMapper()
        {
            MapperConfiguration userMapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<userPoco, userDTO>();
                cfg.CreateMap<userContactDetailsPoco, userContactDetailsDTO>();
                cfg.CreateMap<List<userAccessPoco>, List<userAccessDTO>>();
                cfg.CreateMap<List<medicalRecordsPoco>, List<medicalRecordsDTO>>();
            });



            Mapper userMapper = new Mapper(userMapperConfig);
            return userMapper;
        }
    }
}
