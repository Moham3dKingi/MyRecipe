using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project_Recipe.Models;

namespace Project_Recipe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class AddPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadRecipe(value);
            }
        }
        public AddPage()
        {
            InitializeComponent();
            // Set the BindingContext of the page to a new recipe.
            BindingContext = new Recipe_Table();
        }
        async void LoadRecipe(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the recipe and set it as the BindingContext of the page.
                Recipe_Table recipe = await App.Database.GetNoteAsync(id);
                BindingContext = recipe;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load Recipe.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var recipe = (Recipe_Table)BindingContext;
            if (!string.IsNullOrWhiteSpace(recipe.Title) && !string.IsNullOrWhiteSpace(recipe.CreatedBy)
                && !string.IsNullOrWhiteSpace(recipe.Ingredients) && !string.IsNullOrWhiteSpace(recipe.Steps))
            {
                await App.Database.SaveNoteAsync(recipe);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var recipe = (Recipe_Table)BindingContext;
            await App.Database.DeleteNoteAsync(recipe);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}
