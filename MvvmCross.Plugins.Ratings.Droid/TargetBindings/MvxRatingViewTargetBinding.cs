using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;

namespace MvvmCross.Plugins.Ratings.Droid.TargetBindings
{
    public class MvxRatingViewTargetBinding : MvxTargetBinding
    {
        protected MvxRatingView RatingView => Target as MvxRatingView;
        public override Type TargetType => typeof(int);
        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

        public MvxRatingViewTargetBinding(MvxRatingView target) 
            : base(target)
        {
        }

        public override void SetValue(object value)
        {
            RatingView.SelectedRating = (int)value;
            RatingView.RefreshViews();
        }

        public override void SubscribeToEvents()
        {
            RatingView.SelectedRatingChanged += RatingViewSelectedRatingChanged;
        }

        private void RatingViewSelectedRatingChanged(object sender, EventArgs e)
        {
            var target = Target as MvxRatingView;

            if (target == null)
                return;

            FireValueChanged(target.SelectedRating);
            target.RefreshViews();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                var target = Target as MvxRatingView;
                if (target != null)
                {
                    target.SelectedRatingChanged -= RatingViewSelectedRatingChanged;
                }
            }
            base.Dispose(isDisposing);
        }
    }
}