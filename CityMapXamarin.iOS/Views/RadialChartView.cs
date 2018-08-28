using System.Collections.Generic;
using CityMapXamarin.Core.Charts;
using CityMapXamarin.Core.Models;
using CityMapXamarin.Core.ViewModels;
using CoreGraphics;
using CoreLocation;
using MapKit;
using Microcharts.iOS;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using SkiaSharp;
using UIKit;

namespace Blank.Views
{
    public class RadialChartView : MvxViewController<RadialGaugeChartViewModel>
    {
        private UIView _mainView;
        public RadialChartView()
        {

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitComponents();
            ApplyBindings();
        }
        private void InitComponents()
        {
            _mainView = new UIView(View.Bounds);
            _mainView.BackgroundColor = UIColor.Gray;
            View.AddSubview(_mainView);

            var chart = new GaugeChart(30, GaugeChartTypes.SectorGaugeChartWhithArrow, "9 September", "Score for the week ending")
            {
                BackgroundColor = new SKColor(255, 255, 255)
            };
            var chartView = new ChartView
            {
                Frame = new CGRect(0, 80, this.View.Bounds.Width, this.View.Bounds.Height-80),
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
                Chart = chart,
            };
            _mainView.AddSubview(chartView);

        }
        private void ApplyBindings()
        {
        }
    }
}