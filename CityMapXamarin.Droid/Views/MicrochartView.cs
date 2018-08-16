using Android.App;
using Android.OS;
using CityMapXamarin.Core.ViewModels;
using Microcharts;
using Microcharts.Droid;
using MvvmCross.Platforms.Android.Views;
using SkiaSharp;

namespace CityMapXamarin.Droid.Views
{
    [Activity(Label = "Microchart")]
    public class MicrochartView : MvxActivity<MicrochartViewModel>
    {
        private ChartView _chart;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MicrochartPage);

            InitChart();
        }

        private Entry[] GerEntries()
        {
            var entries = new[]
            {
                new Entry(200)
                {
                    Label = "January",
                    ValueLabel = "200",
                    Color=SKColor.Parse("#266489")
                },
                new Entry(400)
                {
                    Label = "February",
                    ValueLabel = "400",
                    Color = SKColor.Parse("#68B9C0")
                },
                new Entry(-100)
                {
                    Label = "March",
                    ValueLabel = "-100",
                    Color = SKColor.Parse("#90D585")
                },
                 new Entry(300)
                {
                    Label = "qwe",
                    ValueLabel = "300",
                    Color = SKColor.Parse("#90D585")
                }
             };


            return entries;
        } 

        private void InitChart()
        {
            _chart = FindViewById<ChartView>(Resource.Id.chart_view1);

            var canSize = _chart.CanvasSize;
            
            var chart = new LineChart()
            {
                Entries = GerEntries(),
                LabelTextSize = 40,
            };

            _chart.Chart = chart;
        }
    }
}