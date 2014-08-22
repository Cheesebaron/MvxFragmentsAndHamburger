using Cirrious.MvvmCross.ViewModels;

namespace Core.ViewModels
{
    public class SecondViewModel
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

        public class SavedState
        {
            public string Name { get; set; }
        }

        public void ReloadState(SavedState savedState)
        {
            Name = savedState.Name;
        }

        public SavedState SaveState()
        {
            return new SavedState
            {
                Name = _name
            };
        }
    }
}
