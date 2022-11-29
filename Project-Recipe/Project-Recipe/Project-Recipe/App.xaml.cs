using Project_Recipe.Services;
using Project_Recipe.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Project_Recipe.Views;
using System.IO;

namespace Project_Recipe
{
    public partial class App : Application
    {
        static RecipeData database;

        // Create the database connection as a singleton.
        public static RecipeData Database
        {
            get
            {
                if (database == null)
                {
                    database = new RecipeData(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyRecipes.db"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
