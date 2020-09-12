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

        [HttpGet("{id}")]
        public IActionResult GetCD(int id)
        {
            return Ok(_cdRepository.GetCD(id));
        }

        [HttpGet]
        public IActionResult GetAllCds()
        {
            return Ok(_cdRepository.GetAllCds());
        }

        [HttpPut]
        public IActionResult CreateCD([FromBody] CDModel cd)
        {
            _cdRepository.CreateCD(cd);
            return Ok(cd);
        }

        [HttpPost]
        public IActionResult UpdateCD([FromBody] CDModel cd)
        {
            _cdRepository.UpdateCD(cd);
            return Ok(cd);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCD(int id)
        {
            _cdRepository.DeleteCD(id);
            return Ok();
        }
    }
}
