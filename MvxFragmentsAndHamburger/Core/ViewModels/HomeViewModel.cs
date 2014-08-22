using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Core.ViewModels
{
    public class HomeViewModel 
        : MvxViewModel
    {
        //public HomeViewModel()
        //{
        //    MenuViewModel = new MenuViewModel();   
        //}

        //public MenuViewModel MenuViewModel { get; set; }

        private MvxCommand _showMenuCommand;

        public ICommand ShowMenuCommand
        {
            get
            {
                _showMenuCommand = _showMenuCommand ?? new MvxCommand(DoShowMenuCommand);
                return _showMenuCommand;
            }
        }

        private void DoShowMenuCommand()
        {
            ShowViewModel<MenuViewModel>();
        }
    }
}
