using GymManagement.Agregateroot.Models;
using GymManagement.DTO;
using GymManagement.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GymManagement.Handler.Services
{
    public class TrainerServiceHandler
    {
        private readonly ITrainerRepository<Trainer> _trainerRepository;
       

        public TrainerServiceHandler(ITrainerRepository<Trainer> trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public SelectList GetAllTrainers()
        {
          
            var trainers = _trainerRepository.GetAllTrainers();
            return new SelectList(trainers, "TrainerId", "Name");
        }
        
        public Trainer GetTrainerById(SlotDTO slotDTO)
        {
            return _trainerRepository.GetTrainerById(slotDTO.TrainerId);
        }
    }
}
