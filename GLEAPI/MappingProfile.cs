using System;
using AutoMapper;
using GLE.Models;
using GLEAPI.Dto;

namespace GLEAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoutineSchedule, RoutineScheduleCreateDto>();
            CreateMap<RoutineSchedule, RoutineScheduleReadDto>();
            CreateMap< RoutineScheduleCreateDto, RoutineSchedule>();
            CreateMap<RoutineScheduleReadDto, RoutineSchedule>();
            CreateMap<User, UserReadDto>();

            CreateMap<RoutineCreateDto, Routine>()
                .ForMember(routine => routine.EndDate, opt =>
                    opt.MapFrom(dto => DateTime.Today.AddMonths(dto.RoutineDuration)));

            CreateMap<Routine, RoutineReadDto>();
            CreateMap<UserCreateTelegramDto, User>();
            CreateMap<Routine, ResponseGetRoutinesDto>();
            CreateMap<RoutineSchedule, ScheduleDto>();


        }
    }
}
