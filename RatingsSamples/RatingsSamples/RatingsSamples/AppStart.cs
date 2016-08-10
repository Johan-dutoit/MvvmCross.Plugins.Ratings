using MvvmCross.Core.ViewModels;
using RatingsSamples.ViewModels;

namespace RatingsSamples
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public void Start(object hint = null)
        {
            ShowViewModel<RatingViewModel>();
        }
    }
}
