using atm_wpf.Commands;
using System.Windows.Input;

namespace atm_wpf.ViewModels
{

    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;


        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }

        public ICommand UpdateViewCommand { get; set; }

    }
}
