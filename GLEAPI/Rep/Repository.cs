using System.Linq;
using GLE.Context;
using GLE.Models;

namespace GLEAPI.Rep
{
    public class Repository : IRepository
    {
        private readonly GLEContext cont;

        public Repository(GLEContext cont)
        {
            this.cont = cont;
        }

        public User GetUserByName(string name)
        {
            return cont.Users.FirstOrDefault(user=>user.Name==name);
        }
        public User GetUserById(int id)
        {
            return cont.Users.FirstOrDefault(user => user.Id == id);
        }
        public Routine GetRoutineById(int id)
        {
            return cont.Routines.FirstOrDefault(routine => routine.Id == id);
        }

        public RoutineSchedule GetRoutineScheduleByRoutineId(int id)
        {
            return cont.RoutineSchedules.FirstOrDefault(routineSchedule => routineSchedule.RoutineId == id);
        }
    }
}
