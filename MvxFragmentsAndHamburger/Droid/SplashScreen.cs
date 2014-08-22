using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace MvxFragmentsAndHamburger
{
    [Activity(Label = "Fragments and Hamburgers", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen() 
            : base(Resource.Layout.splash)
        { }
    }
}