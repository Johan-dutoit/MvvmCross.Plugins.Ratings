## MvvmCross.Plugins.Ratings

### Setup
* Available on NuGet: https://www.nuget.org/packages/MvvmCross.Plugins.Ratings/ [![NuGet](https://img.shields.io/nuget/v/MvvmCross.Plugins.Ratings.svg?label=NuGet)](https://www.nuget.org/packages/MvvmCross.Plugins.Ratings/)
* Install into your PCL project and Client projects.

**Platform Support**

|Platform|Supported|Version|
| ------------------- | :-----------: | :------------------: |
|Xamarin.Android|Yes|API 15+|

**Target Bindings**
            `registry.RegisterCustomBindingFactory<MvxRatingView>("SelectedRating", ratingView => new MvxRatingViewTargetBinding(ratingView));`
