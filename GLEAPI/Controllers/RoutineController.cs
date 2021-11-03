using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GLE.Context;
using GLE.Models;
using GLEAPI.Dto;
using GLEAPI.Rep;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GLEAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoutineController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly GLEContext context;
        private readonly IRepository repos;
        public RoutineController(IMapper mapper, GLEContext context, IRepository repos)
        {
            this.mapper = mapper;
            this.context = context;
            this.repos = repos;
        }
        [HttpPost]
        public ActionResult<RoutineWithScheduleDto> CreateRoutineWithSchedule(RequestCreateRoutineDto dto)
        {
            var routine = mapper.Map<Routine>(dto.Routine);
            Request.Headers.TryGetValue("id", out var id);
            routine.UserId = int.Parse(id);
            context.Routines.Add(routine);
            context.SaveChanges();

            var routineSchedule = mapper.Map<RoutineSchedule>(dto.Schedule);
            routineSchedule.RoutineId = routine.Id;
            routineSchedule.UserId = int.Parse(Request.Headers["id"]);
            context.RoutineSchedules.Add(routineSchedule);
            context.SaveChanges();

            var response = new RoutineWithScheduleDto
            {
                Routine = mapper.Map<RoutineReadDto>(routine),
                Schedule = mapper.Map<ScheduleDto>(routineSchedule)
            };

            return Ok(response);
        }

        [Route("Routine")]
        [HttpPost]
        public ActionResult<RoutineReadDto> CreateRoutine(RoutineCreateDto dto)
        {
            DateTime time = DateTime.Today.ToUniversalTime();
            time.AddMonths(dto.RoutineDuration);
            var rout = mapper.Map<Routine>(dto);
            rout.EndDate = time;
            this.context.Routines.Add(rout);
            context.SaveChanges();
            return Ok(mapper.Map<RoutineReadDto>(rout));
        }

        [HttpGet]
        public ActionResult<List<RoutineReadDto>> GetAllPublicRoutines()
        {

            Request.Headers.TryGetValue("id", out var id);
            var user = context.Users
                 .Include(user => user.Routines)
                 .ThenInclude(routine => routine.Schedule)
                 .FirstOrDefault(user => user.Id == int.Parse(id));

            var response = new ResponseGetRoutinesDto();
            foreach (Routine item in user.Routines)
            {
                var routine = new RoutineWithScheduleDto
                {
                    Routine = mapper.Map<RoutineReadDto>(item),
                    Schedule = mapper.Map<ScheduleDto>(item.Schedule)
                };
                response.Routines.Add(routine);
            }

            return Ok(response);
        }
    }
}
