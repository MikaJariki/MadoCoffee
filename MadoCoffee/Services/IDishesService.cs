using MadoCoffee.DTO;

namespace MadoCoffee.Services
{
    public interface IDishesService
    {
        void CreateDish(DishDto newDishDto);
        DishDto GetDishById(long id);
        List<DishDto> GetAllDishes();
        void UpdateDish(long id, DishDto updatedDishDto);
        void DeleteDish(long id);
    }
}
