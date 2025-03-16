
using MadoCoffee.DTO;
using MadoCoffee.Models;
using MadoCoffee.Repositories;

namespace MadoCoffee.Services
{
    public class DishesService : IDishesService
    {
        private readonly IDishesRepository _dishesRepository;
        private readonly IFileService _fileService;
        private const string ImageDirectory = "images";
        private readonly string[] AllowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

        public DishesService(IDishesRepository dishesRepository, IFileService fileService)
        {
            _dishesRepository = dishesRepository;
            _fileService = fileService;
        }

        public void CreateDish(DishDto newDishDto)
        {
            if (newDishDto.Image != null)
            {
                string fileName = _fileService.SaveFile(newDishDto.Image, ImageDirectory, AllowedExtensions);
                newDishDto.ImageUrl = $"{fileName}";
            }

            var dish = new Dish
            {
                Name = newDishDto.Name,
                Category = newDishDto.Category,
                Price = newDishDto.Price,
                Description = newDishDto.Description,
                ImageUrl = newDishDto.ImageUrl
            };

            _dishesRepository.AddDish(dish);
        }

        public DishDto GetDishById(long id)
        {
            var dish = _dishesRepository.GetDishById(id);
            if (dish == null)
            {
                throw new Exception("Dish not found");
            }

            return new DishDto
            {
                Name = dish.Name,
                Category = dish.Category,
                Price = dish.Price,
                Description = dish.Description,
                ImageUrl = dish.ImageUrl
            };
        }

        public List<DishDto> GetAllDishes()
        {
            var dishes = _dishesRepository.GetAllDishes();
            var dishDtos = new List<DishDto>();

            foreach (var dish in dishes)
            {
                dishDtos.Add(new DishDto
                {
                    Name = dish.Name,
                    Category = dish.Category,
                    Price = dish.Price,
                    Description = dish.Description,
                    ImageUrl = dish.ImageUrl
                });
            }

            return dishDtos;
        }

        public void UpdateDish(long id, DishDto updatedDishDto)
        {
            var existingDish = _dishesRepository.GetDishById(id);
            if (existingDish == null)
            {
                throw new Exception("Dish not found");
            }

            if (updatedDishDto.Image != null)
            {
                if (!string.IsNullOrEmpty(existingDish.ImageUrl))
                {
                    string oldFileName = Path.GetFileName(existingDish.ImageUrl);
                    _fileService.DeleteFile(oldFileName, ImageDirectory);
                }

                string newFileName = _fileService.SaveFile(updatedDishDto.Image, ImageDirectory, AllowedExtensions);
                existingDish.ImageUrl = $"{newFileName}";
            }

            existingDish.Name = updatedDishDto.Name;
            existingDish.Category = updatedDishDto.Category;
            existingDish.Price = updatedDishDto.Price;
            existingDish.Description = updatedDishDto.Description;

            _dishesRepository.UpdateDish(id, existingDish);
        }

        public void DeleteDish(long id)
        {
            var dish = _dishesRepository.GetDishById(id);
            if (dish == null)
            {
                throw new Exception("Dish not found");
            }

            // Xóa ảnh nếu có
            if (!string.IsNullOrEmpty(dish.ImageUrl))
            {
                string fileName = Path.GetFileName(dish.ImageUrl);
                _fileService.DeleteFile(fileName, ImageDirectory);
            }

            _dishesRepository.DeleteDish(dish);
        }
    }
}
