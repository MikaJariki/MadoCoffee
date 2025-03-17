using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadoCoffee.DTO;

namespace MadoCoffee.Services
{
    public interface IShiftsService
    {
        void CreateShift(ShiftDto newShiftDto);
        ShiftDto GetShiftById(long id);
        List<ShiftDto> GetAllShifts();
        void UpdateShift(long id, ShiftDto updatedShiftDto);
        void DeleteShift(long id);
    }
}