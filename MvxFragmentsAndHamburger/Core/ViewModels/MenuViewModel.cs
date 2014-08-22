using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Core.ViewModels
{
    public class MenuViewModel 
        : MvxViewModel
    {
        public MenuViewModel()
        {
            MenuItems = new List<BaseMenuItemViewModel>
            {
                new GroupMenuItemViewModel
                {
                    Title = "ViewModels"
                },
                new MenuItemViewModel(typeof(FirstViewModel))
                {
                    Title = "First"
                },
                new MenuItemViewModel(typeof(SecondViewModel))
                {
                    Title = "Second (Saves state)"
                }
            };
        }

        private List<BaseMenuItemViewModel> _menuItems;

        public List<BaseMenuItemViewModel> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value; 
                RaisePropertyChanged(() => MenuItems);
            }
        }

        private MvxCommand<MenuItemViewModel> _clickCommand;

        public ICommand ClickCommand
        {
            get
            {
                _clickCommand = _clickCommand ?? new MvxCommand<MenuItemViewModel>(DoClickCommand);
                return _clickCommand;
            }
        }

        private void DoClickCommand(MenuItemViewModel arg)
        {
            arg.ShowViewModelCommand.Execute(null);
        }
    }

    public class BaseMenuItemViewModel 
        : MvxViewModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }
    }

    public class GroupMenuItemViewModel 
        : BaseMenuItemViewModel
    { }

    public class MenuItemViewModel
        : BaseMenuItemViewModel
    {
        public MenuItemViewModel(Type navigatesToViewModel = null)
        {
            NavigatesToViewModelType = navigatesToViewModel;
        }

        private int _badgeCount;
        private string _imageUrl;

        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                RaisePropertyChanged(() => ImageUrl);
            }
        }

        public int BadgeCount
        {
            get { return _badgeCount; }
            set
            {
                _badgeCount = value;
                RaisePropertyChanged(() => BadgeCount);
            }
        }

        public Type NavigatesToViewModelType { get; private set; }

        private MvxCommand _showViewModelCommand;

        public ICommand ShowViewModelCommand
        {
            get
            {
                _showViewModelCommand = _showViewModelCommand ??
                                        new MvxCommand(DoShowViewModelCommand, () => NavigatesToViewModelType != null);
                return _showViewModelCommand;
            }
        }

        private void DoShowViewModelCommand()
        {
            ShowViewModel(NavigatesToViewModelType);
        }
    }
}
