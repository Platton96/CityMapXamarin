
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
        private ChartView _gradientChart;
        private ChartView _smallChart;
        private ChartView _sectorChart;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.RadialChartPage);
            InitChart();

        }
        private void InitChart()
        {
            _gradientChart = FindViewById<ChartView>(Resource.Id.radial_chart_view);
            _smallChart= FindViewById<ChartView>(Resource.Id.radial_small_chart_view);
            _sectorChart= FindViewById<ChartView>(Resource.Id.sector_radial_chart_view);

            var chart = new GaugeChart(75, GaugeChartTypes.GradientGaugeChartWhithArrow, "September 9", "Score for the week ending")
            {
                BackgroundColor= new SKColor(255, 255, 255)
            };
            var smallChart = new GaugeChart(75, GaugeChartTypes.GradientGaugeChartWhithoutArrow, "8/27")
            {
                BackgroundColor = new SKColor(255, 255, 255)
            };
            var sectorChart = new GaugeChart(65, GaugeChartTypes.SectorGaugeChartWhithArrow, "September 9", "Score for the week ending")
            {
                BackgroundColor = SKColors.Green
            };

            _gradientChart.Chart = chart;
            _smallChart.Chart = smallChart;
            _sectorChart.Chart = sectorChart;
        }

    }
}