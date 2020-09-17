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
    [Route("api")]
    [ApiController]
    public class CDsController : ControllerBase
    {
        private readonly ICDRepository _cdRepository;

        public CDsController(ICDRepository cdRepository)
        {
            _cdRepository = cdRepository;
        }

        [HttpGet("cd/{id}")]
        public IActionResult GetCD(int id)
        {
            return Ok(_cdRepository.GetCD(id));
        }

        [HttpGet("cds")]
        public IActionResult GetAllCds()
        {
            return Ok(_cdRepository.GetAllCds());
        }

        [HttpPut("cd")]
        public IActionResult CreateCD([FromBody] CDModel cd)
        {
            _cdRepository.CreateCD(cd);
            return Ok(cd);
        }

        [HttpPut("cds")]
        public IActionResult CreateCDs([FromBody] IEnumerable<CDModel> cds)
        {
            _cdRepository.CreateCDs(cds);
            return Ok(cds);
        }

        [HttpPost("cd")]
        public IActionResult UpdateCD([FromBody] CDModel cd)
        {
            _cdRepository.UpdateCD(cd);
            return Ok(cd);
        }

        [HttpDelete("cd/{id}")]
        public IActionResult DeleteCD(int id)
        {
            _cdRepository.DeleteCD(id);
            return Ok();
        }
    }
}