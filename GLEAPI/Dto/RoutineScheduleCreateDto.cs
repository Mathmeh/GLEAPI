using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using static GLE.Models.RoutineSchedule;

namespace GLEAPI.Dto
{
    public class RoutineScheduleCreateDto
    {
        
        public RoutineTimes Mon { get; set; }
        public RoutineTimes Tue { get; set; }
        public RoutineTimes Wed { get; set; }
        public RoutineTimes Th { get; set; }
        public RoutineTimes Fri { get; set; }
        public RoutineTimes Sat { get; set; }
        public RoutineTimes Sun { get; set; }
    }
}
