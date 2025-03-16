using Microsoft.AspNetCore.Mvc;
using MadoCoffee.Services;
using MadoCoffee.DTO;

namespace MadoCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDishesService _dishesService;

        public DishesController(IDishesService dishesService)
        {
            _dishesService = dishesService;
        }

        [HttpPost("CreateDish")]
        public IActionResult CreateDish([FromForm] DishDto newDishDto)
        {
            if (newDishDto == null)
            {
                return BadRequest(new { message = "Invalid dish data!" });
            }
            _dishesService.CreateDish(newDishDto);
            return Ok(new { message = "Dish created successfully!" });
        }

        [HttpGet("GetDishById/{id}")]
        public IActionResult GetDishById(long id)
        {
            var dish = _dishesService.GetDishById(id);
            if (dish == null)
            {
                return NotFound(new { message = "Dish not found!" });
            }
            return Ok(dish);
        }

        [HttpGet("GetAllDishes")]
        public IActionResult GetAllDishes()
        {
            var dishes = _dishesService.GetAllDishes();
            return Ok(dishes);
        }

        [HttpPut("UpdateDish/{id}")]
        public IActionResult UpdateDish(long id, [FromForm] DishDto updateDishDto)
        {
            if (updateDishDto == null)
            {
                return BadRequest(new { message = "Invalid dish data!" });
            }
            try
            {
                _dishesService.UpdateDish(id, updateDishDto);
                return Ok(new { message = "Dish updated successfully!" });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }


        [HttpDelete("DeleteDish/{id}")]
        public IActionResult DeleteDish(long id)
        {
            try
            {
                _dishesService.DeleteDish(id);
                return Ok(new { message = "Dish deleted successfully!" });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
