using System;
using System.Collections.Generic;
using ETag.Misc;
using ETag.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ETag.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        [ETagFilter]
        public Data Get()
        {
            return Data.GetData();
        }
    }
}
