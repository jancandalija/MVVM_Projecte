using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMarcane2.utilities;
using MVVMarcane2.viewmodel;
using System.Windows.Input;

namespace MVVMarcane2.viewmodel
{
    class NavigationVM : utilities.ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnProperyChanged(); }
        }
        public ICommand HomeCommand { get; set; }
        public ICommand WeaponsCommand { get; set; }
        public ICommand UsuariCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Weapons(object obj) => CurrentView = new WeaponsVM(1);
        private void Usuari(object obj) => CurrentView = new UsuariVM(1);

        

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            WeaponsCommand = new RelayCommand(Weapons);
            UsuariCommand = new RelayCommand(Usuari);

            // Startup Page
            CurrentView = new HomeVM();
        }

    }
}
