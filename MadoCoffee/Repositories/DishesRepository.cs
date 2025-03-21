using MadoCoffee;
using MadoCoffee.Models;
using MadoCoffee.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MadoCoffee.Repositories
{
    public class DishesRepository : IDishesRepository
    {
        private readonly AppDbContext _context;

        public DishesRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddDish(Dish newDish)
        {
            _context.Dishes.Add(newDish);
            _context.SaveChanges();
        }

        public Dish GetDishById(long id)
        {
            return _context.Dishes.Find(id);
        }

        public List<Dish> GetAllDishes()
        {
            return _context.Dishes.ToList();
        }

        public void UpdateDish(long id, Dish updateDish)
        {
            _context.Dishes.Update(updateDish);
            _context.SaveChanges();
        }
        public void DeleteDish(Dish dish)
        {
            _context.Dishes.Remove(dish);
            _context.SaveChanges();
        }
      
    }
}