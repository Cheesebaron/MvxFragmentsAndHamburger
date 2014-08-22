using Android.Content;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Core.ViewModels;

namespace MvxFragmentsAndHamburger.Helpers
{
    public class MenuAdapter : MvxAdapter
    {
        public MenuAdapter(Context context, IMvxAndroidBindingContext bindingContext) 
            : base(context, bindingContext)
        { }

        public override int GetItemViewType(int position)
        {
            var item = GetRawItem(position);
            if (item is GroupMenuItemViewModel)
                return 0;
            return 1;
        }

        public override int ViewTypeCount
        {
            get { return 2; }
        }

        protected override View GetBindableView(View convertView, object source, int templateId)
        {
            if (source is GroupMenuItemViewModel)
                templateId = Resource.Layout.group_item;
            else if (source is MenuItemViewModel)
                templateId = Resource.Layout.menu_item;

            return base.GetBindableView(convertView, source, templateId);
        }
    }
}