using GymManagement.Agregateroot.Models;
using System.Collections.Generic;

namespace GymManagement.Repository
{
    public interface ISlotRepository<T> where T : class
    {
        IEnumerable<T> GetAllSlots();
        T GetSlotById(int slotId);
        int AddSlot(T entity);
        void DeleteSlot(int slotId);
        void UpdateSlot(T entity);
    }
}
