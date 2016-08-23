using System.ComponentModel;
using CoreGraphics;
using Foundation;
using MvvmCross.Plugins.Ratings.iOS;
using UIKit;

namespace RatingsSamples.iOS.Controls
{
    [Register("MyRatingView"), DesignTimeVisible(true)]
    public class MyRatingView : MvxRatingView
    {
        public MyRatingView(CGRect rect)
            : base(rect)
        {

        }

        public override UIView GetRatingViewItem(int rating, bool isSelected)
        {
            return new UITextView()
            {
                Text = rating.ToString(),
                TextColor = UIColor.Black
            };

        }

        public override void UpdateView(UIView view, int rating, bool isSelected)
        {
            var textView = view as UITextView;
            textView.Text = isSelected ? "Y" : rating.ToString();
        }
    }
}
