using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadoCoffee.DTO;

namespace MadoCoffee.Services
{
    public interface IIngredientsService
    {
        void CreateIngredient(IngredientDto newIngredientDto);
        IngredientDto GetIngredientById(long id);
        List<IngredientDto> GetAllIngredients();
        void UpdateIngredient(long id, IngredientDto updatedIngredientDto);
        void DeleteIngredient(long id);   
    }
}