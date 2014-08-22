using Android.App;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.Droid.Fragging.Presenter;
using Cirrious.MvvmCross.ViewModels;
using Core.ViewModels;
using MvxFragmentsAndHamburger.Helpers;


namespace MvxFragmentsAndHamburger.Views
{
    [Activity(Label = "Home")]
    public class HomeView
        : MvxCachingFragmentActivity
        , IMvxFragmentHost
    {
        private DrawerLayout _drawer;
        private MyActionBarDrawerToggle _drawerToggle;
        private MenuView _menu;

        private string _title;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RegisterForDetailsRequests(bundle);

            SetContentView(Resource.Layout.home);
            
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            _drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            _drawer.SetDrawerShadow(Resource.Drawable.drawer_shadow_light, (int)GravityFlags.Start);
            _drawerToggle = new MyActionBarDrawerToggle(this, _drawer, Resource.Drawable.ic_drawer_dark,
                Resource.String.drawer_open, Resource.String.drawer_close);
            _drawerToggle.DrawerClosed += (_, e) => InvalidateOptionsMenu();
            _drawerToggle.DrawerOpened += (_, e) => InvalidateOptionsMenu();
            _drawer.SetDrawerListener(_drawerToggle);

            if (bundle == null)
            {
                ViewModel.ShowMenuCommand.Execute(null);

                _drawer.OpenDrawer((int)GravityFlags.Left);
            }
        }

        private void RegisterForDetailsRequests(Bundle bundle)
        {
            RegisterFragment<FirstView, FirstViewModel>("First", bundle);
            RegisterFragment<SecondView, SecondViewModel>("Second", bundle);
            RegisterFragment<MenuView, MenuViewModel>("Menu", bundle);
        }

        public void RegisterFragment<TFragment, TViewModel>(string tag, Bundle args, IMvxViewModel viewModel = null) 
            where TFragment : IMvxFragmentView where TViewModel : IMvxViewModel
        {
            var customPresenter = Mvx.Resolve<IMvxFragmentsPresenter>();
            customPresenter.RegisterViewModelAtHost<TViewModel>(this);
            RegisterFragment<TFragment, TViewModel>(tag);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            _drawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            _drawerToggle.OnConfigurationChanged(newConfig);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return _drawerToggle.OnOptionsItemSelected(item) || base.OnOptionsItemSelected(item);
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            var drawerOpen = _drawer.IsDrawerOpen((int)GravityFlags.Left);

            for (var i = 0; i < menu.Size(); i++)
                menu.GetItem(i).SetVisible(!drawerOpen);

            return base.OnPrepareOptionsMenu(menu);
        }

        public new HomeViewModel ViewModel
        {
            get { return (HomeViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
        }

        bool IMvxFragmentHost.Show(MvxViewModelRequest request, Bundle bundle)
        {
            if (request.ViewModelType == typeof(FirstViewModel))
            {
                ShowFragment("First", Resource.Id.content_frame, bundle);
                return true;
            }
            if (request.ViewModelType == typeof(SecondViewModel))
            {
                ShowFragment("Second", Resource.Id.content_frame, bundle);
                return true;
            }
            if (request.ViewModelType == typeof (MenuViewModel))
            {
                ShowFragment("Menu", Resource.Id.left_drawer, bundle);
                return true;
            }

            return false;
        }
    }
}