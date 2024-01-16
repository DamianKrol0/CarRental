using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Domain.Entities.Cars>> GetAll();
        Task<Domain.Entities.Cars> GetCarById(int id);
        Task Create(Domain.Entities.Cars car);
        Task Commit();
    }
}
