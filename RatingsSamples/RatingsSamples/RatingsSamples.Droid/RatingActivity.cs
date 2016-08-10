using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using RatingsSamples.ViewModels;

namespace RatingsSamples.Droid
{
    [Activity(Label = "RatingsSamples.Droid", Icon = "@drawable/icon")]
    public class RatingActivity : MvxActivity<RatingViewModel>
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Rating);
        }
    }
}


