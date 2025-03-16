using MadoCoffee.Models;

namespace MadoCoffee.Repositories
{
    public interface IDishesRepository
    {
        void AddDish(Dish newDish);
        Dish GetDishById(long id);
        List<Dish> GetAllDishes();
        void UpdateDish(long id, Dish updateDish);
        void DeleteDish(Dish dish);
    }
}
