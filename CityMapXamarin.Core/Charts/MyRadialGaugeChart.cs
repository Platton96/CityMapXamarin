using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityMapXamarin.Core.Charts
{
    public class MyRadialGaugeChart : RadialGaugeChart
    {
        public MyRadialGaugeChart() : base()
        {

        }
        public override void DrawContent(SKCanvas canvas, int width, int height)
        {
            base.DrawContent(canvas, width, height);
        }
    }
}
