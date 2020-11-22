using System.Collections.Generic;
using Archive.CDManagement.Api.Models;
using Archive.CDManagement.Api.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Archive.CDManagement.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class CDsController : ControllerBase
    {
        private readonly ICDRepository _cdRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="CDsController"/> class.
        /// </summary>
        /// <param name="cdRepository">The cd repository.</param>
        public CDsController(ICDRepository cdRepository)
        {
            _cdRepository = cdRepository;
        }
        /// <summary>
        /// Gets the cd.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("cd/{id}")]
        public IActionResult GetCD(int id)
        {
            return Ok(_cdRepository.GetCD(id));
        }
        /// <summary>
        /// Creates the cd.
        /// </summary>
        /// <param name="cd">The cd.</param>
        /// <returns></returns>
        [HttpPut("cd")]
        public IActionResult CreateCD([FromBody] CDModel cd)
        {
            _cdRepository.CreateCD(cd);
            return Ok(cd);
        }
        /// <summary>
        /// Gets all CDS.
        /// </summary>
        /// <returns></returns>
        [HttpGet("cds")]
        public IActionResult GetAllCds()
        {
            return Ok(_cdRepository.GetAllCds());
        }
        /// <summary>
        /// Creates the c ds.
        /// </summary>
        /// <param name="cds">The CDS.</param>
        /// <returns></returns>
        [HttpPut("cds")]
        public IActionResult CreateCDs([FromBody] IEnumerable<CDModel> cds)
        {
            _cdRepository.CreateCDs(cds);
            return Ok(cds);
        }
        /// <summary>
        /// Updates the cd.
        /// </summary>
        /// <param name="cd">The cd.</param>
        /// <returns></returns>
        [HttpPost("cd")]
        public IActionResult UpdateCD([FromBody] CDModel cd)
        {
            _cdRepository.UpdateCD(cd);
            return Ok(cd);
        }
        /// <summary>
        /// Deletes the cd.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("cd/{id}")]
        public IActionResult DeleteCD(int id)
        {
            _cdRepository.DeleteCD(id);
            return Ok();
        }
    }
}