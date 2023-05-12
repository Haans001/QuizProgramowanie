using Microsoft.EntityFrameworkCore;
using QuizPOG.Store;
using QuizPOG.View;
using QuizPOG.ViewModel;
using QuizProgramowanie.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace QuizPOG
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {

            string connectionString = "Data Source=QuizProg.db";


            QuizDBContextFactory quizDBContextFactory = new QuizDBContextFactory(
                new DbContextOptionsBuilder().UseSqlite(connectionString).Options);

            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new QuestionListViewModel(navigationStore);


            QuizDBContext context = quizDBContextFactory.Create();
            context.Database.EnsureCreated();
            context.Database.Migrate();

            DatabaseLocator.QuizDBContext = context;


            MainWindow window = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            window.Show();
            base.OnStartup(e);
        }
    }
}
