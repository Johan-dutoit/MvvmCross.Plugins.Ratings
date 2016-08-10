using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;
using MvvmCross.Plugins.Ratings.Droid.TargetBindings;

namespace MvvmCross.Plugins.Ratings.Droid
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.CallbackWhenRegistered<IMvxTargetBindingFactoryRegistry>(RegisterDefaultBindings);
        }

        public void RegisterDefaultBindings(IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterCustomBindingFactory<MvxRatingView>("SelectedRating", ratingView => new MvxRatingViewSelectedRatingTargetBinding(ratingView));
            registry.RegisterCustomBindingFactory<MvxRatingView>("ReadOnly", ratingView => new MvxRatingViewSelectedRatingTargetBinding(ratingView));
        }
    }
}