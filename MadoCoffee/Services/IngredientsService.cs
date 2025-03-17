using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadoCoffee.DTO;
using MadoCoffee.Models;
using MadoCoffee.Repositories;

namespace MadoCoffee.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredientsRepository _ingredientsRepository;

        public IngredientsService(IIngredientsRepository ingredientsRepository)
        {
            _ingredientsRepository = ingredientsRepository;
        }

        public void CreateIngredient(IngredientDto newIngredientDto)
        {
            var ingredient = new Ingredient
            {
                Name = newIngredientDto.Name,
                Quantity = newIngredientDto.Quantity,
                Price = newIngredientDto.Price,
                UnitID = newIngredientDto.UnitID,
                Description = newIngredientDto.Description,
            };

            _ingredientsRepository.CreateIngredient(ingredient);
        }

        public void DeleteIngredient(long id)
        {
            var ingredient = _ingredientsRepository.GetIngredientById(id);
            if (ingredient == null)
            {
                throw new Exception("Ingredient not found");
            }

            _ingredientsRepository.DeleteIngredient(ingredient);
        }

        public List<IngredientDto> GetAllIngredients()
        {
            var ingredients = _ingredientsRepository.GetAllIngredients();
            var ingredientDtos = new List<IngredientDto>();

            foreach (var ingredient in ingredients)
            {
                ingredientDtos.Add(new IngredientDto
                {
                    Name = ingredient.Name,
                    Quantity = ingredient.Quantity,
                    Price = ingredient.Price,
                    UnitID = ingredient.UnitID,
                    Description = ingredient.Description,
                });
            }

            return ingredientDtos;
        }

        public IngredientDto GetIngredientById(long id)
        {
            var ingredient = _ingredientsRepository.GetIngredientById(id);
            if (ingredient == null)
            {
                throw new Exception("Ingredient not found");
            }

            return new IngredientDto
            {
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
                Price = ingredient.Price,
                UnitID = ingredient.UnitID,
                Description = ingredient.Description,
            };
        }

        public void UpdateIngredient(long id, IngredientDto updatedIngredientDto)
        {
            var existingIngredient = _ingredientsRepository.GetIngredientById(id);
            if (existingIngredient == null)
            {
                throw new Exception("Ingredient not found");
            }

            existingIngredient.Name = updatedIngredientDto.Name;
            existingIngredient.Quantity = updatedIngredientDto.Quantity;
            existingIngredient.Price = updatedIngredientDto.Price;
            existingIngredient.UnitID = updatedIngredientDto.UnitID;
            existingIngredient.Description = updatedIngredientDto.Description;

            _ingredientsRepository.UpdateIngredient(id, existingIngredient);
        }
    }
}