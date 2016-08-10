using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;

namespace MvvmCross.Plugins.Ratings.Droid.TargetBindings
{
    public class MvxRatingViewReadOnlyTargetBinding : MvxTargetBinding
    {
        protected MvxRatingView RatingView => Target as MvxRatingView;
        public override Type TargetType => typeof(bool);
        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;

        public MvxRatingViewReadOnlyTargetBinding(MvxRatingView target) 
            : base(target)
        {
        }

        public override void SetValue(object value)
        {
            RatingView.ReadOnly = (bool)value;
        }

        public override void SubscribeToEvents()
        {
            RatingView.ReadOnlyChanged += RatingViewReadOnlyChanged;
        }

        private void RatingViewReadOnlyChanged(object sender, EventArgs e)
        {
            if (RatingView == null)
                return;

            FireValueChanged(RatingView.ReadOnly);
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (RatingView != null)
                {
                    RatingView.SelectedRatingChanged -= RatingViewReadOnlyChanged;
                }
            }
            base.Dispose(isDisposing);
        }
    }
}