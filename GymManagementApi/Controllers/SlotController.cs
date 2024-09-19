using GymManagement.Agregateroot.Models;
using GymManagement.DTO;
using GymManagement.Handler.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlotController : ControllerBase
    {
        private readonly SlotServiceHandler slotServiceHandler;
        private readonly TrainerServiceHandler trainerServiceHandler;

        public SlotController(SlotServiceHandler slotServiceHandler, TrainerServiceHandler trainerServiceHandler)
        {
            this.slotServiceHandler = slotServiceHandler;
            this.trainerServiceHandler = trainerServiceHandler;
        }

        [HttpGet("slots")]
        public IActionResult GetAllSlots()
        {
            var slots = slotServiceHandler.GetAllSlots();
            return Ok(slots);
        }

        [HttpPost("slots")]
        public IActionResult AddSlot( SlotDTO slotDto)
        {
            if (slotDto == null)
                return BadRequest("Slot data is null");

            slotServiceHandler.AddSlot(slotDto);
            return CreatedAtAction(nameof(AddSlot), new { id = slotDto.SlotId }, slotDto);
        }

        [HttpDelete("slots/{id}")]
        public IActionResult DeleteSlot(int id)
        {
            var slotDto = new SlotDTO { SlotId = id };
            slotServiceHandler.DeleteSlot(slotDto);
            return NoContent();
        }

        [HttpPut("slots/{id}")]
        public IActionResult UpdateSlot(int id, [FromBody] SlotDTO slotDto)
        {
            if (id != slotDto.SlotId)
                return BadRequest("Slot ID mismatch");

            slotServiceHandler.UpdateSlot(slotDto);
            return NoContent();
        }

        [HttpGet("trainers")]
        public IActionResult GetAllTrainers()
        {
            var trainers = trainerServiceHandler.GetAllTrainers();
            return Ok(trainers);
        }
    }
}
