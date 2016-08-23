using System;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using RatingsSamples.iOS.Controls;
using RatingsSamples.ViewModels;
using UIKit;

namespace RatingsSamples.iOS
{
    [MvxFromStoryboard("Main")]
    public partial class ViewController : MvxViewController<RatingViewModel>
    {

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var myRatingView = new MyRatingView(this.placeholder.Frame);
            this.placeholder.AddSubview(myRatingView);

            var set = this.CreateBindingSet<ViewController, RatingViewModel>();
            set.Bind(myRatingView).For(s => s.SelectedRating).To(vm => vm.Rating);
            //set.Bind(myRatingView).For(s => s.ReadOnly).To(vm => vm.ReadOnly);
            set.Apply();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

           
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

