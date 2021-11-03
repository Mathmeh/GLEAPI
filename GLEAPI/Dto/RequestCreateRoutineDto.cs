using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLEAPI.Dto
{
    public class RequestCreateRoutineDto
    {
        public RoutineCreateDto Routine { get; set; }
        public RoutineScheduleCreateDto Schedule {get; set;}
    }
}
