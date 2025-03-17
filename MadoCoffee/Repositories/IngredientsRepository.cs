using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadoCoffee.Models;

namespace MadoCoffee.Repositories
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly AppDbContext _context;

        public IngredientsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateIngredient(Ingredient newIngredient)
        {
            _context.Ingredients.Add(newIngredient);
            _context.SaveChanges();
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();
        }

        public List<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients.ToList();
        }

        public Ingredient GetIngredientById(long id)
        {
            return _context.Ingredients.Find(id);
        }

        public void UpdateIngredient(long id, Ingredient updateIngredient)
        {
            _context.Ingredients.Update(updateIngredient);
            _context.SaveChanges();
        }
    }
}