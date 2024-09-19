using GymManagement.Agregateroot.Models;
using GymManagement.Repository.Data;
using System.Collections.Generic;
using System.Linq;

namespace GymManagement.Repository
{
    public class SlotRepository<T> : ISlotRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public SlotRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAllSlots()
        {
            return _context.Set<T>().ToList();
        }

        public T GetSlotById(int slotId)
        {
            return _context.Set<T>().Find(slotId);

        }

        public int AddSlot(T slot)
        {
            _context.Set<T>().Add(slot);
           

            int rowCount = _context.SaveChanges();
            if (rowCount > 0)
            {
              
                return rowCount;  
            }
            else
            {
              
                throw new Exception("Failed to save the slot.");
            }
        }

        public void DeleteSlot(int slotId)
        {
            var slot = _context.Set<T>().Find(slotId);
            if (slot != null)
            {
                _context.Set<T>().Remove(slot);
                _context.SaveChanges();
            }
        }

        public void UpdateSlot(T slot)
        {
            _context.Set<T>().Update(slot);
            _context.SaveChanges();
        }
    }
}
