using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityMapXamarin.Core.Charts
{
    public class MyLineChart : LineChart
    {
        public MyLineChart() : base()
        {
        }
        public override void DrawContent(SKCanvas canvas, int width, int height)
        {
            var valueLabelSizes = MeasureValueLabels();
            var footerHeight = CalculateFooterHeight(valueLabelSizes);
            var headerHeight = CalculateHeaderHeight(valueLabelSizes);
            var itemSize = CalculateItemSize(width, height, footerHeight, headerHeight);
            var origin = CalculateYOrigin(itemSize.Height, headerHeight);
            var points = base.CalculatePoints(itemSize, origin, headerHeight);

            base.DrawContent(canvas, width, height);
        }
    }
}
