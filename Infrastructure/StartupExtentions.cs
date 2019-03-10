using AutoMapper;
using NewYearMusic.Domain.Entities;
using NewYearMusic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewYearMusic.Infrastructure
{
    public static class StartupExtentions
    {
        public static void AddAutoMapperConfiguration()
        {
            Mapper.Initialize(cfg =>
            cfg.CreateMap<Song, SongItemViewModel>()
            .ForMember(dto => dto.User, conf => conf.MapFrom(ol => ol.User.UserName)));
        }
    }
}
