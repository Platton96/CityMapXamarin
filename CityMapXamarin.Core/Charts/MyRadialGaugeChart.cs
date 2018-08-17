using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityMapXamarin.Core.Charts
{
    public class MyRadialGaugeChart : RadialGaugeChart
    {
        private Entry _entry;
        private float _maxValue;
        private float AbsoluteMinimum;
        private float ValueRange;
        public MyRadialGaugeChart(Entry entry) 
        {
            _entry = entry;
            LineSize = 3;
            AbsoluteMinimum =0;
            _maxValue = 100;
            ValueRange = _maxValue - AbsoluteMinimum;
        }
        public override void DrawContent(SKCanvas canvas, int width, int height)
        {
            var radius = (Math.Min(width, height) - (2 * Margin)) / 2;
            var cx = width / 2;
            var cy = height / 2;
            var lineWidth = LineSize;
            MyDrawGauge(canvas, _entry, radius, cx, cy, lineWidth);
            MyDrawGaugeArea(canvas, _entry, radius, cx, cy, lineWidth);
        }

        public void MyDrawGauge(SKCanvas canvas, Entry entry, float radius, int cx, int cy, float strokeWidth)
        {
            var colors = new[] {  SKColors.Yellow, SKColors.Green };
            var center = new SKPoint(cx, cy);
            SKShader shader;
            using ( shader = SKShader.CreateSweepGradient(center, colors, null))
            using (var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = strokeWidth,
                StrokeCap = SKStrokeCap.Round,
                Shader=shader,
                IsAntialias = true,
            })
            {
                using (SKPath path = new SKPath())
                {
                    var sweepAngle = 360 * (Math.Abs(entry.Value) - this.AbsoluteMinimum) / this.ValueRange;
                    path.AddArc(SKRect.Create(cx - radius, cy - radius, 2 * radius, 2 * radius), this.StartAngle, sweepAngle);
                    canvas.DrawPath(path, paint);
                }
            }
        }

        public void MyDrawGaugeArea(SKCanvas canvas, Entry entry, float radius, int cx, int cy, float strokeWidth)
        {
            using (var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = strokeWidth-25,
                Color = SKColors.Gray.WithAlpha(this.LineAreaAlpha),
                IsAntialias = true,
            })
            {
                canvas.DrawCircle(cx, cy, radius, paint);
            }
        }
    }
}
