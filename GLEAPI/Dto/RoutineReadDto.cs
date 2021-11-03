using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLEAPI.Dto
{
    public class RoutineReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EndDate { get; set; }//когда рутина закончится
        public string Motivation { get; set; }
    }
}
