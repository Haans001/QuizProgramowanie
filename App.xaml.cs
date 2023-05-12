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

            NavigationStore navigationStore = new NavigationStore();


            QuizDBContext context = new QuizDBContext();
            context.Database.EnsureCreated();

            DatabaseLocator.QuizDBContext = context;

            navigationStore.CurrentViewModel = new QuestionListViewModel(navigationStore);

            MainWindow window = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            window.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            DatabaseLocator.QuizDBContext.Dispose();
            base.OnExit(e);
        }
    }
}
