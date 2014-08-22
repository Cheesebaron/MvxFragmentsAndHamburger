using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Core.ViewModels;

namespace MvxFragmentsAndHamburger.Views
{
    public class FirstView : BaseView<FirstViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.first, container, false);
            return view;
        }

        public override void OnResume()
        {
            Mvx.Trace("FirstView OnResume");
            base.OnResume();
        }

        public override void OnPause()
        {
            Mvx.Trace("FirstView OnPause");
            base.OnPause();
        }

        public override void OnStart()
        {
            Mvx.Trace("FirstView OnStart");
            base.OnStart();
        }

        public override void OnStop()
        {
            Mvx.Trace("FirstView OnStop");
            base.OnStart();
        }

        public override void OnAttach(Activity activity)
        {
            Mvx.Trace("FirstView OnAttach");
            base.OnAttach(activity);
        }

        public override void OnDetach()
        {
            Mvx.Trace("FirstView OnDetach");
            base.OnDetach();
        }
    }
}