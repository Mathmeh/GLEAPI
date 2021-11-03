using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GLE.Context;
using Microsoft.AspNetCore.Mvc;

namespace GLEAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelegramController: ControllerBase
    {
        private readonly GLEContext context;
        private readonly IMapper mapper;
        public TelegramController(IMapper mapper, GLEContext context)
        {
            this.mapper = mapper;
            this.context = context;

        }
    }
}
