

using FluentValidation;
using GymManagement.DTO;
using GymManagement.Repository;
using GymManagement.Agregateroot.Models;
using System.Collections.Generic;

namespace GymManagement.Handler.Services
{
    public class SlotServiceHandler
    {
        private readonly ISlotRepository<Slot> _slotRepository;
        private readonly IValidator<SlotDTO> _slotDtoValidator;
        private readonly ITrainerRepository<Trainer> _trainerRepository;

        public SlotServiceHandler(ISlotRepository<Slot> slotRepository, IValidator<SlotDTO> slotDtoValidator, ITrainerRepository<Trainer> trainerRepository)
        {
            _slotRepository = slotRepository;
            _slotDtoValidator = slotDtoValidator;
            _trainerRepository = trainerRepository;
        }

        public IEnumerable<SlotDTO> GetAllSlots()
        {
            var slots = _slotRepository.GetAllSlots();
            var slotDTOs = new List<SlotDTO>();

            foreach (var slot in slots)
            {
                var slotDto = new SlotDTO();  
                slot.ToSlotDTO(slotDto);      
                slotDTOs.Add(slotDto);        
            }

            return slotDTOs;
        }

       

        public SlotDTO GetSlotById(SlotDTO slotDto)
        {
            var slot = _slotRepository.GetSlotById(slotDto.SlotId);
            if (slot == null) return null;

            slot.ToSlotDTO(slotDto);  
            return slotDto;
        }

        public void AddSlot(SlotDTO slotDto)
        {
           
            var validationResult = _slotDtoValidator.Validate(slotDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Validation failed", validationResult.Errors);
            }

          
            var trainerExists = _trainerRepository.GetTrainerById(slotDto.TrainerId);
            if (trainerExists == null)
            {
                throw new KeyNotFoundException("Trainer not found.");
            }

          
            var slot = new Slot(slotDto);
            _slotRepository.AddSlot(slot);  
        }

        public void UpdateSlot(SlotDTO slotDto)
        {
           
            var validationResult = _slotDtoValidator.Validate(slotDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Validation failed", validationResult.Errors);
            }

            // Retrieve the existing slot by ID
            var slot = _slotRepository.GetSlotById(slotDto.SlotId);
            if (slot == null)
            {
                throw new KeyNotFoundException("Slot not found.");
            }

            // Check if the trainer exists
            var trainerExists = _trainerRepository.GetTrainerById(slotDto.TrainerId);
            if (trainerExists == null)
            {
                throw new KeyNotFoundException("Trainer not found.");
            }

            // Update the existing slot with new data from SlotDTO
            slot.UpdateFromDTO(slotDto);
            _slotRepository.UpdateSlot(slot);
        }

        public void DeleteSlot(SlotDTO slotDto)
        {
            // Find the slot by ID using SlotDTO's SlotId
            var slot = _slotRepository.GetSlotById(slotDto.SlotId);
            if (slot == null)
            {
                throw new KeyNotFoundException("Slot not found.");
            }

            _slotRepository.DeleteSlot(slotDto.SlotId);
        }
    }
}
