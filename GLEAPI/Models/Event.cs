using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLE.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int RoutineScheduleId { get; set; }
        public DateTime Date { get; set; }
    }
}
