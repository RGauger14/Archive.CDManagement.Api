using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archive.CDManagement.Api.Models;
using Archive.CDManagement.Api.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Archive.CDManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CDsController : ControllerBase
    {
        private readonly ICDRepository _cdRepository;

        public CDsController(ICDRepository cdRepository)
        {
            _cdRepository = cdRepository;
        }

        [HttpGet]
        public IActionResult GetCD(int id)
        {
            return Ok(_cdRepository.GetCDModel(id));
        }
    }
}
