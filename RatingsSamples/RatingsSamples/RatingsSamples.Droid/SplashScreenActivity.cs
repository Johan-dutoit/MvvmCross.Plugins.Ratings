using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace RatingsSamples.Droid
{
    [Activity(
        MainLauncher = true,
        Icon = "@drawable/icon",
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        LaunchMode = LaunchMode.SingleInstance
        )]
    public class SplashScreenActivity : MvxSplashScreenActivity
    {

        public SplashScreenActivity()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}