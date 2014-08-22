using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Fragging.Presenter;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using Core;
using MvxFragmentsAndHamburger.Helpers;

namespace MvxFragmentsAndHamburger
{
    public class Setup 
        : MvxAndroidSetup
    {
        public Setup(Context applicationContext) 
            : base(applicationContext)
        { }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var customPresenter = new MvxFragmentsPresenter();
            Mvx.RegisterSingleton<IMvxFragmentsPresenter>(customPresenter);
            return customPresenter;
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}