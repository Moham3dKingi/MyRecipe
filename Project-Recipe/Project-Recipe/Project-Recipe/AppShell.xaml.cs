using Project_Recipe.ViewModels;
using Project_Recipe.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Project_Recipe
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));
            Routing.RegisterRoute(nameof(ReadRecipePage), typeof(ReadRecipePage));
        }

    }
}
