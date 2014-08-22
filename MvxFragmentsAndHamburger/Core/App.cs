using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using Core.ViewModels;

namespace Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            // Start the app with the First View Model.
            RegisterAppStart<HomeViewModel>();
        }
    }
}
