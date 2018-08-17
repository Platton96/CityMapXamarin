﻿using Android.App;
using Android.OS;
using CityMapXamarin.Core.Charts;
using CityMapXamarin.Core.ViewModels;
using Microcharts;
using Microcharts.Droid;
using MvvmCross.Platforms.Android.Views;
using SkiaSharp;

namespace CityMapXamarin.Droid.Views
{
    [Activity(Label = "Microchart")]
    public class LineChartView : MvxActivity<LineChartViewModel>
    {
        private ChartView _chart;
        private ChartView _chart2;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LineChartPage);

            InitChart();
        }

        private Entry[] GetEntries1()
        {
            var entries = new[]
            {
                new Entry(200)
                {
                    Color=SKColors.Green
                },
                new Entry(400)
                {
                    Color = SKColors.Green
                },
                new Entry(-100)
                {
                    Color =SKColors.Green
                },
                 new Entry(300)
                {

                    Color = SKColors.Green
                }
             };


            return entries;
        }

        private SKPoint[] GetPoints()
        {
            var entries = new[]
            {
                new SKPoint()
                {
                    X=142.5f,
                    Y=265f
                },
                new SKPoint()
                {
                    X=407.5f,
                    Y=166f
                },
                new SKPoint()
                {
                    X=672.5f,
                    Y=640f
                },
                new SKPoint()
                {
                    X=937.5f,
                    Y=340f
                }

             };


            return entries;
        }
        private Entry[] GetEntries2()
        {
            var entries = new[]
            {
                new Entry(123)
                {
                    Label = "8/12",
                    Color=SKColor.Parse("#266489")
                },
                new Entry(268)
                {
                    Label = "8/11",
                    Color = SKColor.Parse("#266489")
                },
                new Entry(300)
                {
                    Label = "5/4",
                    Color = SKColor.Parse("#266489")
                },
                 new Entry(176)
                {
                    Label = "3/4",
                    Color = SKColor.Parse("#266489")
                }
             };
            return entries;
        }
        private void InitChart()
        {
            _chart = FindViewById<ChartView>(Resource.Id.chart_view1);
            _chart2 = FindViewById<ChartView>(Resource.Id.chart_view2);

            var chart = new LineChart()
            {
                Entries = GetEntries1(),
                LineSize=8,
                PointSize = 30,
                LineAreaAlpha =0
            };
            var chart2 = new LineChart()
            {
                Entries = GetEntries2(),
                LineAreaAlpha = 78,
                PointSize = 30,
                LabelTextSize = 40,
                BackgroundColor = SKColors.Transparent,
                LineSize=8
            };


            //chart.MyDrawLine(points2, itemSize2);
            //chart.MyDrawLine(points3, itemSize3);
            _chart.Chart = chart;
            _chart2.Chart = chart2;
        }
    }
}