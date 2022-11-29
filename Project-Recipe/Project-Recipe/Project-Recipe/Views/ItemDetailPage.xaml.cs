using Project_Recipe.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Project_Recipe.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}