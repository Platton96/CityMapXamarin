
using Android.App;
using Android.OS;
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
            var entry1 = new Entry(82);

            var chart = new GaugeChart(50, GaugeChartTypes.SectorGaugeChartWhithArrow)
            {
                BackgroundColor=SKColors.Transparent
            };

            _chart.Chart = chart;
        }

    }
}