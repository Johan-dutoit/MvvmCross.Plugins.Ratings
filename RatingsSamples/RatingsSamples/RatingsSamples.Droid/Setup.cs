using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;

namespace RatingsSamples.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }


        //protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        //{
        //    typeof(Android.Support.Design.Widget.NavigationView).Assembly,
        //    typeof(Android.Support.Design.Widget.FloatingActionButton).Assembly,
        //    typeof(Android.Support.V7.Widget.Toolbar).Assembly,
        //    typeof(Android.Support.V4.Widget.DrawerLayout).Assembly,
        //    typeof(Android.Support.V4.View.ViewPager).Assembly,
        //    typeof(Android.Support.Design.Widget.TabLayout).Assembly,
        //    typeof(Android.Support.Design.Widget.AppBarLayout).Assembly,
        //    typeof(Android.Support.Design.Widget.CoordinatorLayout).Assembly,
        //    typeof(Android.Support.Design.Widget.Snackbar).Assembly,
        //    typeof(MvvmCross.Droid.Support.V7.RecyclerView.MvxRecyclerView).Assembly,
        //};
    }
}