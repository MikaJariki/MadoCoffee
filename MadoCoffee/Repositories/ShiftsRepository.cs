using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadoCoffee.Models;

namespace MadoCoffee.Repositories
{
    public class ShiftsRepository : IShiftsRepository
    {
        private readonly AppDbContext _context;

        public ShiftsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateShift(Shift newShift)
        {
            _context.Shifts.Add(newShift);
            _context.SaveChanges();
        }

        public void DeleteShift(Shift shift)
        {
            _context.Shifts.Remove(shift);
            _context.SaveChanges();
        }

        public List<Shift> GetAllShifts()
        {
            return _context.Shifts.ToList();
        }

        public Shift GetShiftById(long id)
        {
            return _context.Shifts.Find(id);
        }

        public void UpdateShift(long id, Shift updatedShift)
        {
            _context.Shifts.Update(updatedShift);
            _context.SaveChanges();
        }
    }
}