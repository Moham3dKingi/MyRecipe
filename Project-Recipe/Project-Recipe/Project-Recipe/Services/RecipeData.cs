using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Project_Recipe.Models;
using System.Threading.Tasks;

namespace Project_Recipe.Services
{
    public class RecipeData
{
        readonly SQLiteAsyncConnection database;

        public RecipeData(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Recipe_Table>().Wait();
        }
        public Task<List<Recipe_Table>> GetNotesAsync()
        {
            //Get all recipes.
            return database.Table<Recipe_Table>().ToListAsync();
        }

        public Task<Recipe_Table> GetNoteAsync(int id)
        {
            // Get a specific recipe.
            return database.Table<Recipe_Table>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Recipe_Table recipe)
        {
            if (recipe.ID != 0)
            {
                // Update an existing recipe.
                return database.UpdateAsync(recipe);
            }
            else
            {
                // Save a new recipe.
                return database.InsertAsync(recipe);
            }
        }

        public Task<int> DeleteNoteAsync(Recipe_Table recipe)
        {
            // Delete a note.
            return database.DeleteAsync(recipe);
        }

    }
}
