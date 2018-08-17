using Microcharts;
using SkiaSharp;
using System.Linq;

namespace CityMapXamarin.Core.Charts
{
    public class MyLineChart : LineChart
    {
        private SKCanvas _canvas;
        public SKPoint[] Points { get;  set; }
        public SKSize ItemSize { get; private set; }
        public MyLineChart() : base()
        {
        }
        public override void DrawContent(SKCanvas canvas, int width, int height)
        {
            _canvas = canvas;
            var valueLabelSizes = MeasureValueLabels();
            var footerHeight = CalculateFooterHeight(valueLabelSizes);
            var headerHeight = CalculateHeaderHeight(valueLabelSizes);
            var itemSize = CalculateItemSize(width, height, footerHeight, headerHeight);
            var origin = CalculateYOrigin(itemSize.Height, headerHeight);
            var points = base.CalculatePoints(itemSize, origin, headerHeight);
            ItemSize = itemSize;

            base.DrawContent(canvas, width, height);
        }
        public void MyDrawLine(SKPoint[] points, SKSize itemSize)
        {
            if (points.Length > 1 && this.LineMode != LineMode.None)
            {
                using (var paint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = SKColors.White,
                    StrokeWidth = this.LineSize,
                    IsAntialias = true,
                })
                {

                    paint.Color = SKColors.Black;

                    var path = new SKPath();

                    path.MoveTo(points.First());

                    var last = (this.LineMode == LineMode.Spline) ? points.Length - 1 : points.Length;
                    for (int i = 0; i < last; i++)
                    {
                        if (this.LineMode == LineMode.Spline)
                        {
                            var entry = this.Entries.ElementAt(i);
                            var nextEntry = this.Entries.ElementAt(i + 1);
                            var cubicInfo = this.CalculateCubicInfo(points, i, itemSize);
                            path.CubicTo(cubicInfo.control, cubicInfo.nextControl, cubicInfo.nextPoint);
                        }
                        else if (this.LineMode == LineMode.Straight)
                        {
                            path.LineTo(points[i]);
                        }
                    }

                    _canvas.DrawPath(path, paint);
                }
            }
        }

        private (SKPoint point, SKPoint control, SKPoint nextPoint, SKPoint nextControl) CalculateCubicInfo(SKPoint[] points, int i, SKSize itemSize)
        {
            var point = points[i];
            var nextPoint = points[i + 1];
            var controlOffset = new SKPoint(itemSize.Width * 0.8f, 0);
            var currentControl = point + controlOffset;
            var nextControl = nextPoint - controlOffset;
            return (point, currentControl, nextPoint, nextControl);
        }

        private SKShader CreateGradient(SKPoint[] points, byte alpha = 255)
        {
            var startX = points.First().X;
            var endX = points.Last().X;
            var rangeX = endX - startX;

            return SKShader.CreateLinearGradient(
                new SKPoint(startX, 0),
                new SKPoint(endX, 0),
                this.Entries.Select(x => x.Color.WithAlpha(alpha)).ToArray(),
                null,
                SKShaderTileMode.Clamp);
        }

    }
}
