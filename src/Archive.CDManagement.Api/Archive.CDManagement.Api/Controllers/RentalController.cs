using Archive.CDManagement.Api.Models;
using Archive.CDManagement.Api.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Archive.CDManagement.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalController(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        [HttpGet("rental/{id}")]
        public IActionResult GetRental(int id)
        {
            return Ok(_rentalRepository.GetRental(id));
        }

        [HttpGet("rentals")]
        public IActionResult GetAllRentals()
        {
            return Ok(_rentalRepository.GetAllRentals());
        }

        [HttpPut("rental")]
        public IActionResult CreateRental([FromBody] RentalModel rental)
        {
            _rentalRepository.CreateRental(rental);
            return Ok(rental);
        }

        [HttpPost("rental")]
        public IActionResult UpdateRental([FromBody] RentalModel rental)
        {
            _rentalRepository.UpdateRental(rental);
            return Ok(rental);
        }

        [HttpDelete("rental/{id}")]
        public IActionResult DeleteRental(int id)
        {
            _rentalRepository.DeleteRental(id);
            return Ok();
        }

        [HttpPost("rental/rentalItem")]
        public IActionResult AddRentalItem([FromBody] RentalItemModel rentalItem)
        {
            _rentalRepository.AddRentalItem(rentalItem);
            return Ok();
        }

        [HttpDelete("rental/{rentalId}/rentalItem/{rentalItemId}")]
        public IActionResult RemoveRentalItem(int rentalId, int rentalItemId)
        {
            _rentalRepository.RemoveRentalItem(rentalId, rentalItemId);
            return Ok();
        }
    }
}