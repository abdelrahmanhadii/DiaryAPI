using AutoMapper;
using DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mappers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Diary, CreateDiaryDTO>().ReverseMap();
            CreateMap<Diary, UpdateDiaryDTO>().ReverseMap();
            CreateMap<Diary, ListDiaryDTO>().ReverseMap();
        }
    }
}
