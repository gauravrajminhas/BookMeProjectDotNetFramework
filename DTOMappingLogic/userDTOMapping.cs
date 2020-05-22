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
            
                cfg.CreateMap<userPoco, userDTO>()
                .ForMember(dest => dest.medicalRecordsListNavigation, imce => imce.MapFrom(src => src.medicalRecordsListNavigation))
                .ForMember(dest => dest.userAccessListNavigation, imce => imce.MapFrom(src => src.userAccessListNavigation));
                cfg.CreateMap<userAccessPoco, userAccessDTO>();
                cfg.CreateMap<medicalRecordsPoco, medicalRecordsDTO>();
                cfg.CreateMap<userContactDetailsPoco, userContactDetailsDTO>();

            });

            
            //TODO Add iMapper IOC /DI controller here 
            Mapper userMapper = new Mapper(userMapperConfig);
            return userMapper;
        }
    }
}
