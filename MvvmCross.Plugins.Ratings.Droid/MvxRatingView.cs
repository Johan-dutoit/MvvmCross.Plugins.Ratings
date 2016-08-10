using System;
using System.Collections.Generic;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MvvmCross.Plugins.Ratings.Droid
{
    public abstract class MvxRatingView : LinearLayout, View.IOnClickListener
    {
        private int _maxRating;
        private bool _readonly;
        private int _selectedRating;

        public event EventHandler SelectedRatingChanged;
        public event EventHandler ReadOnlyChanged;

        public int SelectedRating
        {
            get { return _selectedRating; }
            set
            {
                if (_selectedRating.Equals(value))
                {
                    return;
                }

                _selectedRating = value;
                RefreshViews();
            }
        }
     
        public bool ReadOnly
        {
            get { return _readonly; }
            set
            {
                if (_readonly.Equals(value))
                {
                    return;
                }

                _readonly = value;
                if (_readonly)
                {
                    AddOnClickListeners();
                }
                else
                {
                    RemoveOnClickListeners();
                }
            }
        }

        private List<View> Views { get; set; }

        protected MvxRatingView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Initialize(context, attrs);
        }

        protected MvxRatingView(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
            Initialize(context, attrs);
        }

        protected MvxRatingView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Initialize(context, attrs);
        }

        private void Initialize(Context context, IAttributeSet attrs)
        {
            Views = new List<View>();

            InitializeAttributes(context, attrs);
            SetupView();
        }

        public abstract View GetRatingViewItem(int rating, bool isSelected);

        public abstract void UpdateView(View view, int rating, bool isSelected);

        public virtual int GetMaxRating()
        {
            return _maxRating;
        }

        public virtual void OnClick(View v)
        {
            SelectedRating = (int)v.Tag;
            SelectedRatingChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RefreshViews()
        {
            foreach (var mvxRatingViewItem in Views)
            {
                var rating = (int)mvxRatingViewItem.Tag;
                var isSelected = SelectedRating >= rating;

                UpdateView(mvxRatingViewItem, rating, isSelected);
            }
        }

        private void RemoveOnClickListeners()
        {
            Views?.ForEach(v =>
            {
                v.SetOnClickListener(null);
            });
        }

        public void AddOnClickListeners()
        {
            Views?.ForEach(v =>
            {
                v.SetOnClickListener(this);
            });
        }

        private void SetupView()
        {
            var maxRating = GetMaxRating();
            for (var i = 1; i <= maxRating; i++)
            {
                var isSelected = SelectedRating >= i;
                var ratingViewItem = GetRatingViewItem(i, isSelected);
                ratingViewItem.Tag = i;

                SetupRatingViewItem(ratingViewItem);
            }
        }

        private void SetupRatingViewItem(View ratingViewItem)
        {
            if (!_readonly)
            {
                ratingViewItem.Clickable = true;
                ratingViewItem.SetOnClickListener(this);
            }

            Views.Add(ratingViewItem);
            AddView(ratingViewItem);
        }

        private void InitializeAttributes(Context context, IAttributeSet attrs)
        {
            try
            {
                var typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.MvxRatingView);
                _maxRating = typedArray.GetInt(Resource.Styleable.MvxRatingView_MaxRating, 5);
                _readonly = typedArray.GetBoolean(Resource.Styleable.MvxRatingView_ReadOnly, false);
                typedArray.Recycle();
            }
            catch (Exception ex)
            {
                _maxRating = 5;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!disposing) return;

            Views?.ForEach(v =>
            {
                v.SetOnClickListener(null);
                v.Dispose();
            });
            Views?.Clear();
            Views = null;
        }
    }
}
