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
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        [HttpGet("staff/{id}")]
        public IActionResult GetStaff(int id)
        {
            return Ok(_staffRepository.GetStaff(id));
        }

        [HttpGet("staff")]
        public IActionResult GetAllStaff()
        {
            return Ok(_staffRepository.GetAllStaff());
        }

        [HttpPut("staff")]
        public IActionResult CreateStaff([FromBody] StaffModel staff)
        {
            _staffRepository.CreateStaff(staff);
            return Ok(staff);
        }

        [HttpPost("staff")]
        public IActionResult UpdateStaff([FromBody] StaffModel staff)
        {
            _staffRepository.UpdateStaff(staff);
            return Ok(staff);
        }

        [HttpDelete("staff/{id}")]
        public IActionResult DeleteStaff(int id)
        {
            _staffRepository.DeleteStaff(id);
            return Ok();
        }
    }
}
