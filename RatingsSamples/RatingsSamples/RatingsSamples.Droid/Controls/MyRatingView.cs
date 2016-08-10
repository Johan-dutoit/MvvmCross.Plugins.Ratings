using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Plugins.Ratings.Droid;

namespace RatingsSamples.Droid.Controls
{
    public class MyRatingView : MvxRatingView
    {
        public MyRatingView(Context context, IAttributeSet attrs) : base(context, attrs) { }

        public MyRatingView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr) { }

        public MyRatingView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes) { }

        public override View GetRatingViewItem(int rating, bool isSelected)
        {
            return new TextView(Context)
            {
                Text = rating.ToString()
            };
        }

        public override void UpdateView(View view, int rating, bool isSelected)
        {
            var textView = view as TextView;
            textView.Text = isSelected ? "Y" : rating.ToString();
        }
    }
}