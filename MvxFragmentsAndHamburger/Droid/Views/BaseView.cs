using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;

namespace MvxFragmentsAndHamburger.Views
{
    public class BaseView<T> 
        : MvxFragment 
        where T : IMvxViewModel
    {
        protected BaseView()
        {
            LocateViewModel();
        }

        public virtual void LocateViewModel()
        {
            //var loaderService = Mvx.Resolve<IMvxViewModelLoader>();
            //ViewModel = Mvx.IocConstruct<T>();
            //ViewModel = (T)loaderService.LoadViewModel(
            //    new MvxViewModelRequest(typeof(T), null, null, null), null);
        }

        public new T ViewModel
        {
            get { return (T) base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}