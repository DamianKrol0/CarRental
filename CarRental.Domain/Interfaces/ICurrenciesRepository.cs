using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces
{
    public interface ICurrenciesRepository
    {
        Task<IEnumerable<Domain.Entities.Currencies>> GetAll();
    }
}
