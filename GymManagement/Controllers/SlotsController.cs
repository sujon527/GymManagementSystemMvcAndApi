using FluentValidation;
using GymManagement.DTO;
using GymManagement.Handler.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GymManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotsController : ControllerBase
    {
        private readonly SlotServiceHandler _slotServiceHandler;
        private readonly TrainerServiceHandler _trainerServiceHandler;

        public SlotsController(SlotServiceHandler slotServiceHandler, TrainerServiceHandler trainerServiceHandler)
        {
            _slotServiceHandler = slotServiceHandler;
            _trainerServiceHandler = trainerServiceHandler;
        }

        // GET: api/slots
        [HttpGet]
        public IActionResult GetAllSlots()
        {
            var slots = _slotServiceHandler.GetAllSlots();
            return Ok(slots);
        }

        // GET: api/slots/{id}
        [HttpGet("{id}")]
        public IActionResult GetSlotById(SlotDTO slotDTO)
        {
            var slot = _slotServiceHandler.GetSlotById(slotDTO);
            if (slot == null)
            {
                return NotFound();
            }
            return Ok(slot);
        }

        // POST: api/slots
        [HttpPost]
        public IActionResult AddSlot([FromBody] SlotDTO slotDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            try
            {
                _slotServiceHandler.AddSlot(slotDto);
                return CreatedAtAction(nameof(GetSlotById), new { id = slotDto.SlotId }, slotDto);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }

        // PUT: api/slots/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSlot(int id, [FromBody] SlotDTO slotDto)
        {
            if (id != slotDto.SlotId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _slotServiceHandler.UpdateSlot(slotDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }

        // DELETE: api/slots/{id}
        //[HttpDelete("{id}")]
        //public IActionResult DeleteSlot(int id)
        //{
        //    try
        //    {
        //        _slotServiceHandler.DeleteSlot(id);
        //        return NoContent();
        //    }
        //    catch (KeyNotFoundException)
        //    {
        //        return NotFound();
        //    }
        //}
        [HttpDelete]
        public IActionResult DeleteSlot([FromBody] SlotDTO slotDto)
        {
            if (slotDto == null || slotDto.SlotId <= 0)
            {
                return BadRequest("Invalid slot data.");
            }

            try
            {
                _slotServiceHandler.DeleteSlot(slotDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


        // GET: api/slots/trainers
        [HttpGet("trainers")]
        public IActionResult GetAllTrainers()
        {
            var trainers = _trainerServiceHandler.GetAllTrainers();
            return Ok(trainers);
        }

        // GET: api/slots/trainers/{id}
        [HttpGet("trainers/{id}")]
        public IActionResult GetTrainerById(SlotDTO slotDTO)
        {
            var trainer = _trainerServiceHandler.GetTrainerById(slotDTO);
            if (trainer == null)
            {
                return NotFound();
            }
            return Ok(trainer);
        }
    }
}
