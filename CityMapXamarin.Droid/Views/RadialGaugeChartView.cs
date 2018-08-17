using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CityMapXamarin.Core.Charts;
using CityMapXamarin.Core.ViewModels;
using Microcharts;
using Microcharts.Droid;
using MvvmCross.Platforms.Android.Views;
using SkiaSharp;

namespace CityMapXamarin.Droid.Views
{
    [Activity(Label = "Linerchart")]
    public class RadialGaugeChartView : MvxActivity<RadialGaugeChartViewModel>
    {
        private ChartView _chart;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.RadialChartPage);
            InitChart();

        }
        private void InitChart()
        {
            _chart = FindViewById<ChartView>(Resource.Id.radial_chart_view);
            var entry1 = new Entry(82)
            {
                Color = SKColors.Red,
            };
            var entry2 = new Entry(44)
            {
                Color = SKColor.Parse("#90D585"),
                ValueLabel = "10",
                Label = "qweqweewqe",
            };
            var chart = new MyRadialGaugeChart(entry1)
            {
                LabelTextSize = 40,
                LineSize = 30,
                MaxValue = 100,
                LineAreaAlpha=10

            };

            

            _chart.Chart = chart;
        }

    }
}