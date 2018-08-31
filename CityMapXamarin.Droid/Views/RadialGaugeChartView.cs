
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
        private ChartView _smallChart;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.RadialChartPage);
            InitChart();

        }
        private void InitChart()
        {
            _chart = FindViewById<ChartView>(Resource.Id.radial_chart_view);
            _smallChart= FindViewById<ChartView>(Resource.Id.radial_small_chart_view);
            var chart = new GaugeChart(75, GaugeChartTypes.GradientGaugeChartWhithArrow, "9 September", "Score for the week ending")
            {
                BackgroundColor= new SKColor(255, 255, 255)
            };
           

            _chart.Chart = chart;
        }

    }
}