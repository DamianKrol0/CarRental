using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces
{
    public interface IRentRepository
    {
        Task<IEnumerable<Domain.Entities.Rents>> GetAll();
        Task<Domain.Entities.Rents> GetRentById(int id);
        Task Create(Domain.Entities.Rents rents);
        Task Commit();
    }
}
