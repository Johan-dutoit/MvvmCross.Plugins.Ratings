using MvvmCross.Core.ViewModels;

namespace RatingsSamples.ViewModels
{
    public class RatingViewModel : MvxViewModel
    {
        public RatingViewModel()
        {
            Rating = 3;
        }

        private int rating;
        private bool isReadOnly;

        public int Rating
        {
            get { return rating; }
            set { SetProperty(ref rating, value); }
        }

        public bool ReadOnly
        {
            get { return isReadOnly; }
            set { SetProperty(ref isReadOnly, value); }
        }
    }
}
