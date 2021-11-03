using AutoMapper;
using GLE.Context;
using GLE.Models;
using GLEAPI.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GLEAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoutineScheduleController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly GLEContext context;
        public RoutineScheduleController(IMapper mapper, GLEContext context)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpPost]
        public ActionResult<RoutineScheduleReadDto> CreateRoutineSchedule(RoutineScheduleCreateDto dto)
        {
            var rs = mapper.Map<RoutineSchedule>(dto);
            this.context.RoutineSchedules.Add(rs);
            context.SaveChanges();
            return Ok(mapper.Map<RoutineScheduleReadDto>(rs));
        }
    }
}
