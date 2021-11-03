using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLE.Models
{
    public class RoutineSchedule
    {
        public enum RoutineTimes { FreeDay = 0, Morning = 1, Afternoon = 2, Evening =3  };
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int RoutineId { get; set; }
        public Routine Routine { get; set; }
        public RoutineTimes Mon { get; set; }
        public RoutineTimes Tue { get; set; }
        public RoutineTimes Wed { get; set; }
        public RoutineTimes Th { get; set; }
        public RoutineTimes Fri { get; set; }
        public RoutineTimes Sat { get; set; }
        public RoutineTimes Sun { get; set; }
    }
}
