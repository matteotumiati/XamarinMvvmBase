using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using BaseXamarinMvvm.Models;

namespace BaseXamarinMvvm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get { return this._people; }
            set { Set(() => People, ref _people, value); }
        }

        private RelayCommand _refreshCommand;
        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new RelayCommand(
                    () =>
                    {
                        People.Clear();

                        People.Add(new Person("Matteo", "Tumiati"));
                        People.Add(new Person("Daniele", "Bochicchio"));

                        var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                        dialog.ShowMessage("Ho finito di caricare i dati", "Completato");

                        RaisePropertyChanged(() => People);
                    }));
            }
        }

        private RelayCommand<Person> _selectedPersonCommand;
        public RelayCommand<Person> SelectedPersonCommand
        {
            get
            {
                return _selectedPersonCommand ?? (_selectedPersonCommand = new RelayCommand<Person>(
                    async (x) =>
                    {
                        var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                        await dialog.ShowMessage(string.Format($"{x.Name} {x.LastName}"), "Persona selezionata");
                    }));
            }
        }
        
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            People = new ObservableCollection<Person>();
        }
    }
}