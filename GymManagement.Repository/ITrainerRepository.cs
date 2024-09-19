using GymManagement.Agregateroot.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GymManagement.Repository
{
    public interface ITrainerRepository<T> 
    {
        IEnumerable<T> GetAllTrainers();
        T GetTrainerById(int trainerId);
    }
}
