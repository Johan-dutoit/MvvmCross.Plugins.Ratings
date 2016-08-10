using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace RatingsSamples
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            // Construct custom application start object
            Mvx.ConstructAndRegisterSingleton<IMvxAppStart, AppStart>();

            var appStart = Mvx.Resolve<IMvxAppStart>();
            RegisterAppStart(appStart);
        }
    }
}

