
using GymManagement.DTO;

namespace GymManagement.Agregateroot.Models
{
    public class Slot
    {
        public int SlotId { get; set; }
        public string SlotName { get; set; }
        public TimeSpan SlotTime { get; set; }
        public string ClassesIncluded { get; set; }
        public bool IsBooked { get; set; }
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }

       
        public Slot(SlotDTO slotDto)
        {
            UpdateFromDTO(slotDto);
        }

        
        public void UpdateFromDTO(SlotDTO slotDto)
        {
            SlotName = slotDto.SlotName;
            //SlotTime = slotDto.SlotTime;
            SlotTime = TimeSpan.Parse(slotDto.SlotTime);
            ClassesIncluded = slotDto.ClassesIncluded;
            IsBooked = slotDto.IsBooked;
            TrainerId = slotDto.TrainerId;
            TrainerName = slotDto.TrainerName;
        }


      
        public void ToSlotDTO(SlotDTO slotDto)
        {
            slotDto.SlotId = SlotId;
            slotDto.SlotName = SlotName;
            //slotDto.SlotTime = SlotTime;
            slotDto.SlotTime = SlotTime.ToString("hh\\:mm\\:ss");
            slotDto.ClassesIncluded = ClassesIncluded;
            slotDto.IsBooked = IsBooked;
            slotDto.TrainerId = TrainerId;
            slotDto.TrainerName = TrainerName;
        }



        public Slot() { }
    }
}
