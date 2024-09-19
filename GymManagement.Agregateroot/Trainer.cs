namespace GymManagement.Agregateroot.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }
       
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Slot> Slots { get; set; }
    }
}
