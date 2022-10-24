using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeMvc.Data;
using RecipeMvc.Models;
using RecipeMvc.Models.ViewModels;

namespace RecipeMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Recipes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Recipes.ToListAsync());
        }

        // GET: Admin/Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var listvm = new RecipeIngredientsViewModel();

            if (id == null)
            {
                return NotFound();
            }

            listvm.Recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            listvm.Ingredients = new SelectList(_context.ingredients.OrderBy(i => i.Name), "IngredientId", "Name");
            listvm.RecipeIngredients = await _context.RecipeIngredients.Where(i => i.Recipe.RecipeId == id).Include(i => i.Ingredient).ToListAsync();
            if (listvm.Recipe == null)
            {
                return NotFound();
            }

            return View(listvm);
        }

        // GET: Admin/Recipes/Create
        public async Task<IActionResult> CreateAsync(int? id = 0)
        {
            RecipeIngredientsViewModel recipeIngredientsVM = new RecipeIngredientsViewModel();
            recipeIngredientsVM.RecipeIngredient = new RecipeIngredient();
            recipeIngredientsVM.Ingredients = new SelectList(_context.ingredients.OrderBy(i => i.Name), "IngredientId", "Name");
            recipeIngredientsVM.RecipeIngredients = await _context.RecipeIngredients.Where(r => r.RecipeId == id).ToListAsync();
            if (id == 0)
            {
                recipeIngredientsVM.Recipe = new Recipe();
            }
            else
            {
                recipeIngredientsVM.Recipe = _context.Recipes.FirstOrDefault(i => i.RecipeId == id);

            }

            return View(recipeIngredientsVM);
        }
        // POST: Admin/Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecipeIngredientsViewModel vm)
        {
            vm.Ingredients = new SelectList(_context.ingredients.OrderBy(i => i.Name), "Id", "Name");

            if (ModelState.IsValid && vm.Recipe.RecipeId == 0)
            {
                _context.Add(vm.Recipe);
                await _context.SaveChangesAsync();
                vm.RecipeIngredient.RecipeId = vm.Recipe.RecipeId;
                _context.Add(vm.RecipeIngredient);
                
                var id = vm.Recipe.RecipeId;
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", new { id = id });
            }
            else if(ModelState.IsValid)
            {
                vm.RecipeIngredient.RecipeId = vm.Recipe.RecipeId;
                _context.Add(vm.RecipeIngredient);

                var id = vm.Recipe.RecipeId;
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", new { id = id });

            }
            return View(vm);
        }

        // GET: Admin/Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var vm = new RecipeIngredientsViewModel();
            vm.Ingredients = new SelectList(_context.ingredients.OrderBy(i => i.Name), "Id", "Name");
            vm.Recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.RecipeId == id);
            vm.RecipeIngredients = await _context.RecipeIngredients.Include(i => i.Ingredient).Where(i => i.Ingredient.IngredientId == id).ToListAsync();

            
            if (vm.Recipe == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        // POST: Admin/Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,Name,RecipePortions,Instructions")] Recipe recipe)
        {
            if (id != recipe.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Admin/Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Admin/Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recipes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Recipes'  is null.");
            }
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
          return _context.Recipes.Any(e => e.RecipeId == id);
        }
    }
}
