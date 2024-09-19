
using GymManagement.Agregateroot.Models;
using GymManagement.DTO;
using GymManagement.Handler.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GymManagement.Controllers
{
    public class TrainerController : Controller
    {
        private readonly SlotServiceHandler slotServiceHandler;
        private readonly TrainerServiceHandler trainerServiceHandler;

        public TrainerController(SlotServiceHandler slotService, TrainerServiceHandler trainerService)
        {
            this.slotServiceHandler = slotService;
            this.trainerServiceHandler = trainerService;
        }

        public IActionResult ManageSlots()
        {
            var slots = slotServiceHandler.GetAllSlots();
            return View(slots);
        }
        
        public IActionResult AddSlot()
        {
            var trainers = trainerServiceHandler.GetAllTrainers();
            ViewBag.Trainers = trainers;
            return View(new SlotDTO());
            
        }

        [HttpPost]
        public IActionResult AddSlot(SlotDTO slotDto)
        {
            //var trainers = trainerServiceHandler.GetAllTrainers();
            slotServiceHandler.AddSlot(slotDto);
            return RedirectToAction(nameof(ManageSlots));
        }

        [HttpPost]
        public IActionResult DeleteSlot(SlotDTO slotDTO)
        {
            slotServiceHandler.DeleteSlot(slotDTO);
            return RedirectToAction(nameof(ManageSlots));
        }
        public IActionResult UpdateSlot(int slotId)
        {
            var trainers = trainerServiceHandler.GetAllTrainers();
            ViewBag.Trainers=trainers;
            //var slot = slotServiceHandler.GetSlotById(slotDto);
            var slot = slotServiceHandler.GetSlotById(new SlotDTO { SlotId = slotId });
            return View(slot);
        }

        [HttpPost]
        public IActionResult UpdateSlot(SlotDTO slotDto)
        {
            slotServiceHandler.UpdateSlot(slotDto);
            return RedirectToAction(nameof(ManageSlots));
        
        }
    }
}

