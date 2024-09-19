using System;

namespace GymManagement.DTO
{
    public class SlotDTO
    {
        public int SlotId { get; set; }
        public string SlotName { get; set; }
        public string SlotTime { get; set; }
        public string ClassesIncluded { get; set; }
        public bool IsBooked { get; set; }
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
    }
}
