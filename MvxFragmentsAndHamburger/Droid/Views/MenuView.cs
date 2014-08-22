using Android.OS;
using Android.Views;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Views;
using Core.ViewModels;
using MvxFragmentsAndHamburger.Helpers;

namespace MvxFragmentsAndHamburger.Views
{
    public class MenuView 
        : BaseView<MenuViewModel>
    {
        private MvxListView _listView;

        public override void LocateViewModel()
        {
            base.LocateViewModel();
            //ViewModel = Mvx.IocConstruct<MenuViewModel>();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var args = Arguments;

            var view = this.BindingInflate(Resource.Layout.menu, container, false);
            _listView = view.FindViewById<MvxListView>(Resource.Id.list_view);
            _listView.Adapter = new MenuAdapter(Activity, (IMvxAndroidBindingContext)BindingContext);

            //var bset = this.CreateBindingSet<MenuView, MenuViewModel>();
            //bset.Bind(_groupListView).To(vm => vm.MenuItems);
            //bset.Apply();

            return view;
        }

        public void SetItemChecked(int position)
        {
            if (_listView != null)
                _listView.SetItemChecked(position, true);
        }
    }
}