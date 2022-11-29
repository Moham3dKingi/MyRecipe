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
    public partial class MyRecipePage : ContentPage
    {
        public MyRecipePage()
        {
            InitializeComponent();
          
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CollectView.ItemsSource = await App.Database.GetNotesAsync();
        }
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the AddPage, passing the ID as a query parameter.
                Recipe_Table recipe = (Recipe_Table)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(ReadRecipePage)}?{nameof(ReadRecipePage.ItemId)}={recipe.ID.ToString()}");
            }

        }
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            // Navigate to the AddPage.
            await Navigation.PushAsync(new AddPage());
        }
    }
}