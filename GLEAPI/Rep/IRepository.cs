using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLE.Context;
using GLE.Models;

namespace GLEAPI.Rep
{
    public interface IRepository 
    {
        User GetUserByName(string name);
        User GetUserById(int id);
        Routine GetRoutineById(int id);
        RoutineSchedule GetRoutineScheduleByRoutineId(int id);
    }
}
