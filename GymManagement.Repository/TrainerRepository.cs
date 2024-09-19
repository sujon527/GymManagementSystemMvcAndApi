using GymManagement.Agregateroot.Models;
using GymManagement.Repository.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GymManagement.Repository
{
    public class TrainerRepository<T> : ITrainerRepository<T>where T:class
    {
        private readonly ApplicationDbContext _context;

        public TrainerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAllTrainers()
        {

            return _context.Set<T>().ToList();
        }
        


        public T GetTrainerById(int trainerId)
        {
            return _context.Set<T>().Find(trainerId);
        }
    }
}
