using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadoCoffee.Models;

namespace MadoCoffee.Repositories
{
    public interface IIngredientsRepository
    {
        void CreateIngredient(Ingredient newIngredient);
        Ingredient GetIngredientById(long id);
        List<Ingredient> GetAllIngredients();
        void UpdateIngredient(long id, Ingredient updateIngredient);
        void DeleteIngredient(Ingredient ingredient);
    }
}