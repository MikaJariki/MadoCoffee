using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadoCoffee.Models;

namespace MadoCoffee.Repositories
{
    public interface IShiftsRepository
    {
        void CreateShift(Shift newShift);
        Shift GetShiftById(long id);
        List<Shift> GetAllShifts();
        void UpdateShift(long id, Shift updatedShift);
        void DeleteShift(Shift shift);
    }
}