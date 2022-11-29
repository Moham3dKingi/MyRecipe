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
    public partial class ReadRecipePage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadRecipe(value);

            }
        }
        public ReadRecipePage()
        {
            InitializeComponent();
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



        async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            var recipe = (Recipe_Table)BindingContext;
            await Shell.Current.GoToAsync($"{nameof(AddPage)}?{nameof(AddPage.ItemId)}={recipe.ID.ToString()}");

        }
    }
}