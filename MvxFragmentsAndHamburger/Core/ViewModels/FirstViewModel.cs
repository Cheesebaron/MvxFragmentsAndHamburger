﻿using Cirrious.MvvmCross.ViewModels;

namespace Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }
    }
}
