using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadoCoffee.DTO;
using MadoCoffee.Models;
using MadoCoffee.Repositories;

namespace MadoCoffee.Services
{
    public class ShiftsService : IShiftsService
    {
        private readonly IShiftsRepository _shiftsRepository;
        public ShiftsService(IShiftsRepository shiftsRepository)
        {
            _shiftsRepository = shiftsRepository;
        }
        public void CreateShift(ShiftDto newShiftDto)
        {
            var shift = new Shift
            {
                Name = newShiftDto.Name,
                StartTime = newShiftDto.StartTime,
                EndTime = newShiftDto.EndTime
            };
            _shiftsRepository.CreateShift(shift);
        }

        public void DeleteShift(long id)
        {
            var shift = _shiftsRepository.GetShiftById(id);
            if (shift != null)
            {
                _shiftsRepository.DeleteShift(shift);
            }
        }

        public List<ShiftDto> GetAllShifts()
        {
            var shifts = _shiftsRepository.GetAllShifts();
            var shiftDtos = new List<ShiftDto>();

            foreach (var shift in shifts)
            {
                shiftDtos.Add(new ShiftDto
                {
                    ID = shift.ID,
                    Name = shift.Name,
                    StartTime = shift.StartTime,
                    EndTime = shift.EndTime
                });
            }

            return shiftDtos;
        }

        public ShiftDto GetShiftById(long id)
        {
            var shift = _shiftsRepository.GetShiftById(id);
            if (shift == null)
            {
                throw new Exception("Shift not found!");
            }

            return new ShiftDto
            {
                ID = shift.ID,
                Name = shift.Name,
                StartTime = shift.StartTime,
                EndTime = shift.EndTime
            };
        }

        public void UpdateShift(long id, ShiftDto updatedShiftDto)
        {
            var existShift = _shiftsRepository.GetShiftById(id);
            if (existShift != null)
            {
                existShift.Name = updatedShiftDto.Name;
                existShift.StartTime = updatedShiftDto.StartTime;
                existShift.EndTime = updatedShiftDto.EndTime;

                _shiftsRepository.UpdateShift(id, existShift);
            }
        }
    }
}