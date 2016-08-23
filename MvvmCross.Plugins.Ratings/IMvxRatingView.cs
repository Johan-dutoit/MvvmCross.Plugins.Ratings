using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross.Plugins.Ratings
{
    public interface IMvxRatingView<T> 
    {
        event EventHandler SelectedRatingChanged;
        event EventHandler ReadOnlyChanged;

        List<T> Views { get; set; }

        int SelectedRating { get; set; }

        bool ReadOnly { get; set; }

        T GetRatingViewItem(int rating, bool isSelected);

        int GetMaxRating();

        void UpdateView(T view, int rating, bool isSelected);

        void RefreshViews();

        void AddOnClickListeners();

        void RemoveOnClickListeners(bool disposing = false);

        void OnClick(T view);

    }
}
