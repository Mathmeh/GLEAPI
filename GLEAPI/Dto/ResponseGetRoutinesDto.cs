using System;
using System.Collections.Generic;
using GLE.Models;

namespace GLEAPI.Dto
{
    public class ResponseGetRoutinesDto
    {
       public List<RoutineWithScheduleDto> Routines { get; set; }
        public ResponseGetRoutinesDto()
        {
            Routines = new List<RoutineWithScheduleDto>();
        }
    }
}
