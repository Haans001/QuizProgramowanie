using QuizPOG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPOG.Store
{
    public class NavigationStore
    {
        private BaseViewModel _currentViewModel { get; set; }

        public event Action CurrentViewModelChanged;

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewChanged();
            }
        }

        private void OnCurrentViewChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
