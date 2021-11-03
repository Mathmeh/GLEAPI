using System;
using System.Collections.Generic;

namespace GLE.Models
{
    public class Routine
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool Publicity { get; set; }
        public int RoutineDuration { get; set; }// сколько месяцев предполагается выполнение рутины
        public DateTime EndDate { get; set; }//когда рутина закончится
        public string Motivation { get; set; }
        public RoutineSchedule Schedule { get; set; }
    }
}
