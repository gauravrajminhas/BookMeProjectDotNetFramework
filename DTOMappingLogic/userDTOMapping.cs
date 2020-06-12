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
                .ForMember(dest => dest.userCredentialsListNavigation, imce => imce.MapFrom(src => src.userCredentialsListNavigation));
                cfg.CreateMap<userCredentialsPoco, userAccessDTO>();
                cfg.CreateMap<medicalRecordsPoco, medicalRecordsDTO>();
                cfg.CreateMap<userContactDetailsPoco, userContactDetailsDTO>();
                cfg.CreateMap<subscriptionsPoco, subscriptionsDTO>();

            });

            
            //TODO Add iMapper IOC /DI controller here 
            Mapper userMapper = new Mapper(userMapperConfig);
            return userMapper;
        }
    }
}
