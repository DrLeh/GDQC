using AutoMapper;
using GDQC.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDQC.Core.MappingProfiles;

internal class ScheduleProfile : Profile
{
    public ScheduleProfile()
    {
        CreateMap<Schedule, ScheduleView>()
            //.ReverseMap()
            ;

        CreateMap<ScheduleGame, ScheduleGameView>()
            //.ReverseMap()
            ;
    }
}
