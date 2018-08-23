using Microcharts;
using SkiaSharp;
using System;

namespace CityMapXamarin.Core.Charts
{
    public class GaugeChart : Chart
    {
        private float _score;
        private GaugeChartTypes _gaugeChartType;

        private Entry _entry;
        private SKCanvas _canvas;
        private float _cx;
        private float _cy;
        private float _radius;

        private const float MIN_VALUE_SCORE = 0;
        private const float MAX_VALUE_SCORE = 100;
        private const float SECTOR_GUAGE_CHART_WITH_ARROW_LINE_WIDTH = 60;

        private const int START_ANGLE = 150;
        private const int SWEEP_ANGLE = 240;
        private const float COEFF_FOR_CALCULATE_SWEEP_ANGLE = 2.4f; //240/100
        public GaugeChart(float score, GaugeChartTypes gaugeChartType)
        {
            if (score < MIN_VALUE_SCORE && score > MAX_VALUE_SCORE)
            {
                throw new ArgumentOutOfRangeException();
            }
            _score = score;
            _gaugeChartType = gaugeChartType;
        }
        public override void DrawContent(SKCanvas canvas, int width, int height)
        {
            _canvas = canvas;
            var radius = (Math.Min(width, height) - (4 * Margin)) / 2;
            _radius = radius;
            var cx = width / 2f;
            var cy = height / 2f;
            _cy = cy;
            _cx = cx;
            //  DrawSmallSpeedometer(radius - 40, cx, cy, START_AGILE, _entry.Value * COEFF_FOR_CALCULATE_END_AGILE, 20);
            DrawSectorGuageChartWithArrow(radius - 40, cx, cy, START_ANGLE, _score * COEFF_FOR_CALCULATE_SWEEP_ANGLE, SECTOR_GUAGE_CHART_WITH_ARROW_LINE_WIDTH);
        }

       
        public void DrawSmallSpeedometer(float radius, int cx, int cy, float startAgile, float sweepAgile, float stokeWidth)
        {
            var shader = ItializeShader(cx, cy, 145);
            var paintFrontLine = InitializePaint(stokeWidth, shader);
            //   var paintBackLine = InitializePaint(stokeWidth, SKColors.Gray.WithAlpha(this.LineAreaAlpha));
            DrawArc(paintFrontLine, radius, cx, cy, startAgile, SWEEP_ANGLE);
            //  DrawArc(paintBackLine, radius, cx, cy, startAgile, END_AGILE);

        }
        public void DrawSectorGuageChartWithArrow(float radius, float cx, float cy, float startAngle, float sweepAngle, float stokeWidth)
        {

            var paintFrontLine1 = InitializePaint(stokeWidth, new SKColor(0, 107, 166));
            var paintFrontLine2 = InitializePaint(stokeWidth, new SKColor(0, 169, 224));
            var paintFrontLine3 = InitializePaint(stokeWidth, new SKColor(225, 242, 247));
            //   var paintBackLine = InitializePaint(stokeWidth, SKColors.Gray.WithAlpha(this.LineAreaAlpha));


            DrawArc(paintFrontLine3, radius, cx, cy, startAngle, 240);
            DrawArc(paintFrontLine2, radius, cx, cy, startAngle, 180);
            DrawArc(paintFrontLine1, radius, cx, cy, startAngle, 60);

            DrawLine(_score, 30, SKColors.White, 0, 80);
            DrawLine(_score, 4, SKColors.LightGray, -60, 150);
            DrawLine(_score, 8, SKColors.Black, 20, 80);

            DrawLabel(cx, cy, _score.ToString(), 240, new SKColor(4, 33, 54));
            DrawLabel(cx, cy+120,"Score for the week ending", 28, new SKColor(171, 185, 192));
            DrawLabel(cx, cy + 180, "September 9", 34, new SKColor(54, 85, 101));
            //  DrawArc(paintBackLine, radius, cx, cy, startAgile, END_AGILE);

        }
        private SKPaint InitializePaint(float stokeWidth, SKColor color)
        {
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = stokeWidth,
                Color = color,
                IsAntialias = true
            };
            return paint;
        }
        private SKPaint InitializePaint(float stokeWidth, SKShader shader)
        {
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = stokeWidth,
                Shader = shader,
                IsAntialias = true
            };
            return paint;
        }
        private void DrawArc(SKPaint paint, float radius, float cx, float cy, float startAgile, float sweepAgile)
        {
            using (SKPath path = new SKPath())
            {
                path.AddArc(SKRect.Create(cx - radius, cy - radius, 2 * radius, 2 * radius), startAgile, sweepAgile);
                _canvas.DrawPath(path, paint);
            }
        }
        private SKShader ItializeShader(float cx, float cy, float agileRotate)
        {
            var colors = new[] { new SKColor(0, 107, 166), new SKColor(0, 169, 224), new SKColor(244, 244, 244) };
            var center = new SKPoint(cx, cy);
            SKMatrix matrix = new SKMatrix();
            SKMatrix.RotateDegrees(ref matrix, agileRotate, cx, cy);

            return SKShader.CreateSweepGradient(center, colors, new float[] { 0.3f, 0.5f, 0.6f }, matrix);
        }
        private void DrawLine(float _ballsCount, float lineWidth, SKColor lineColor, float upIndentFromCircle, float downIndentFromCircle)
        {
            const float BEGIN_ANGLE = 60f;
            var angle = COEFF_FOR_CALCULATE_SWEEP_ANGLE * _ballsCount + BEGIN_ANGLE;
            var x1 = _cx - (_radius - downIndentFromCircle) * (float)Math.Sin(angle * (Math.PI / 180f));
            var y1 = _cy + (_radius - downIndentFromCircle) * (float)Math.Cos(angle * (Math.PI / 180f));

            var x2 = _cx - (_radius + upIndentFromCircle) * (float)Math.Sin(angle * (Math.PI / 180f));
            var y2 = _cy + (_radius + upIndentFromCircle) * (float)Math.Cos(angle * (Math.PI / 180f));

            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = lineWidth,
                Color = lineColor,
                IsAntialias = true
            };

            _canvas.DrawLine(x1, y1, x2, y2, paint);

        }
        private void DrawLabel(float x, float y, string text, float textSize, SKColor textColor)
        {

            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                TextSize = textSize,
                Color = textColor,
                IsAntialias = true,
                IsStroke = false,
                TextAlign = SKTextAlign.Center
            };
            _canvas.DrawText(text, x, y, paint);

        }
    }
}
