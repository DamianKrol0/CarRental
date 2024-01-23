using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;

namespace CarRental.Domain.Interfaces
{
    public interface ICurrenicesRepository
    {
        Task<IEnumerable<Currencies>> GetAllCurrenices();
    }
}
