using Microcharts;
using SkiaSharp;
using System;

namespace CityMapXamarin.Core.Charts
{
    public class GaugeChart : Chart
    {
        private float _score;
        private GaugeChartTypes _gaugeChartType;
        private string _scoreTitle;
        private string _statisticDate;

        private SKCanvas _canvas;
        private float _cx;
        private float _cy;
        private float _radius;

        private const float MIN_VALUE_SCORE = 0;
        private const float MAX_VALUE_SCORE = 100;
        private const float SECTOR_GUAGE_CHART_WITH_ARROW_LINE_WIDTH = 60;

        private const float BEGIN_ANGLE = 60f;
        private const float END_ANGLE = 300f;

        private const int START_ANGLE = 150;
        private const int SWEEP_ANGLE = 240;
        private const float COEFF_FOR_CALCULATE_SWEEP_ANGLE = 2.4f; //240/100
        public GaugeChart(float score, GaugeChartTypes gaugeChartType)
        {
            CheakValidationScoreValue(score);
            _score = score;
            _gaugeChartType = gaugeChartType;
        }
        public GaugeChart(float score, GaugeChartTypes gaugeChartType, string statisticDate)
        {
            CheakValidationScoreValue(score);
            _score = score;
            _gaugeChartType = gaugeChartType;
            _statisticDate = statisticDate;

        }
        public GaugeChart(float score, GaugeChartTypes gaugeChartType, string statisticDate, string scoreTitle)
        {
            CheakValidationScoreValue(score);
            _score = score;
            _gaugeChartType = gaugeChartType;
            _statisticDate = statisticDate;
            _scoreTitle = scoreTitle;
        }
        public override void DrawContent(SKCanvas canvas, int width, int height)
        {
            _canvas = canvas;
            var radius = Math.Min(width, height) * 0.4f;
            _radius = radius;
            var cx = width / 2f;
            var cy = height / 2f;
            _cy = cy;
            _cx = cx;
            //  DrawSmallSpeedometer(radius - 40, cx, cy, START_AGILE, _entry.Value * COEFF_FOR_CALCULATE_END_AGILE, 20);
            var lineTickeness = radius * 0.22f;
            DrawSectorGuageChartWithArrow(radius, cx, cy, START_ANGLE, lineTickeness, _scoreTitle, _statisticDate);

            //var lineTickeness = radius / 8;
            //DrawGradientGuageChartWithoutArrow(radius, cx, cy, START_ANGLE, _score, lineTickeness, _statisticDate);

            //var lineTickeness = radius * 0.22f;
            //DrawGradientGuageChartWithSmallCircle(radius, cx, cy, START_ANGLE, _score, lineTickeness, _scoreTitle, _statisticDate);
        }


        public void DrawSmallSpeedometer(float radius, int cx, int cy, float startAgile, float sweepAgile, float stokeWidth)
        {
            var shader = InitializeShader(cx, cy, 145);
            var paintFrontLine = InitializePaint(stokeWidth, shader);
            //   var paintBackLine = InitializePaint(stokeWidth, SKColors.Gray.WithAlpha(this.LineAreaAlpha));
            DrawArc(paintFrontLine, radius, cx, cy, startAgile, SWEEP_ANGLE);
            //  DrawArc(paintBackLine, radius, cx, cy, startAgile, END_AGILE);

        }
        public void DrawSectorGuageChartWithArrow(float radius, float cx, float cy, float startAngle, float lineThickness, string scoreTitle, string statisticDate)
        {
            var beginSectorColor = new SKColor(0, 107, 166);
            var midleSectorColor = new SKColor(0, 169, 224);
            var endSectorColor = new SKColor(225, 242, 247);

            var breakLineColor = SKColors.White;
            var boldLineColor = new SKColor(5, 36, 57);
            var thinLineColor = new SKColor(240, 241, 242);

            var beginSectorPaint = InitializePaint(lineThickness, beginSectorColor);
            var midleSectorPaint = InitializePaint(lineThickness, midleSectorColor);
            var endSectorPaint = InitializePaint(lineThickness, endSectorColor);

            var beginSectorAngle = 60f;
            var midleSectorAngle = 180f;
            var endSectorAngle = 240f;

            var breakLineThickness = 0.09f * radius;
            var boldLineThickness = breakLineThickness *0.3f;
            var thinLineThickness = boldLineThickness / 2f;


            var upIndentFromCircleForBreakLine = lineThickness/2;
            var downIndentFromCircleForBreakLine = lineThickness/2+10;

            var upIndentFromCircleForBoldLine = 0.07f * radius+lineThickness / 2; ;
            var downIndentFromCircleForrBoldLine = lineThickness/2 + 0.07f * radius;

            var upIndentFromCircleForThinLine = 0f;
            var downIndentFromCircleFoThinLine = 0.33f * radius+ lineThickness / 2;

            var scoreColor = new SKColor(0, 24, 47);
            var scoreValueLabelSize = 0.41f * radius;

            var scoreTitleLabelColor = new SKColor(180, 193, 199);
            var scoreTitleLabelSize = 0.1f * radius;
            var scoreTitleLabelY = cy + 0.37f * radius;

            var statisticDateLabelColor = new SKColor(0, 24, 47);
            var statisticDateLabelSize = 0.1f * radius + 2;
            var statisticDateLabelY = cy + 0.54f * radius;
            //   var paintBackLine = InitializePaint(stokeWidth, SKColors.Gray.WithAlpha(this.LineAreaAlpha));


            DrawArc(endSectorPaint, radius, cx, cy, startAngle, endSectorAngle);
            DrawArc(midleSectorPaint, radius, cx, cy, startAngle, midleSectorAngle);
            DrawArc(beginSectorPaint, radius, cx, cy, startAngle, beginSectorAngle);

            DrawPaintedCircle(radius, cx, cy, BEGIN_ANGLE, beginSectorColor);
            DrawPaintedCircle(radius, cx, cy, END_ANGLE, endSectorColor);

            DrawLine(_score, breakLineThickness, breakLineColor, upIndentFromCircleForBreakLine, downIndentFromCircleForBreakLine);
            DrawLine(_score, thinLineThickness, thinLineColor, upIndentFromCircleForThinLine, downIndentFromCircleFoThinLine);
            DrawLine(_score, boldLineThickness, boldLineColor, upIndentFromCircleForBoldLine, downIndentFromCircleForrBoldLine);

            DrawLabel(cx, cy, _score.ToString(), scoreValueLabelSize, scoreColor);
            DrawLabel(cx, scoreTitleLabelY, scoreTitle, scoreTitleLabelSize, scoreTitleLabelColor);
            DrawLabel(cx, statisticDateLabelY, statisticDate, statisticDateLabelSize, statisticDateLabelColor);

        }

        public void DrawGradientGuageChartWithoutArrow(float radius, float cx, float cy, float startAngle, float score, float lineThickness, string statisticDate = "")
        {
            var backgroundLineColor = new SKColor(241, 241, 241);
            var backgroundLinePaint = InitializePaint(lineThickness, backgroundLineColor);
            DrawArc(backgroundLinePaint, radius, cx, cy, startAngle, SWEEP_ANGLE);

            var gradientRotateAngle = 145f;
            var gradient = InitializeShader(cx, cy, gradientRotateAngle);
            var gradientLinePaint = InitializePaint(lineThickness, gradient);
            DrawArc(gradientLinePaint, radius, cx, cy, startAngle, score * COEFF_FOR_CALCULATE_SWEEP_ANGLE);

            var scoreColor = new SKColor(0, 24, 47);
            var scoreValueLabelSize = radius / 2;
            DrawLabel(cx, cy, score.ToString(), scoreValueLabelSize, scoreColor);

            if (!string.IsNullOrEmpty(statisticDate))
            {
                var statisticDateLabelColor = new SKColor(180, 193, 199);
                var statisticDateLabelSize = radius / 4;
                var statisticDateLabelY = cy + radius / 2;
                DrawLabel(cx, statisticDateLabelY, statisticDate, statisticDateLabelSize, statisticDateLabelColor);
            }

        }

        public void DrawGradientGuageChartWithSmallCircle(float radius, float cx, float cy, float startAngle, float score, float lineThickness, string scoreTitle, string statisticDate)
        {
            var backgroundLineColor = new SKColor(241, 241, 241);
            var backgroundLinePaint = InitializePaint(lineThickness, backgroundLineColor);
            DrawArc(backgroundLinePaint, radius, cx, cy, startAngle, SWEEP_ANGLE);

            var startColor = new SKColor(28, 114, 169);
            DrawPaintedCircle(radius, cx, cy, BEGIN_ANGLE, startColor);

            var gradientRotateAngle = 140f;
            var gradient = InitializeShader(cx, cy, gradientRotateAngle);
            var gradientLinePaint = InitializePaint(lineThickness, gradient);
            DrawArc(gradientLinePaint, radius, cx, cy, startAngle, score * COEFF_FOR_CALCULATE_SWEEP_ANGLE);

            var scoreColor = new SKColor(0, 24, 47);
            var scoreValueLabelSize = 0.41f * radius;
            DrawLabel(cx, cy, score.ToString(), scoreValueLabelSize, scoreColor);

            var scoreTitleLabelColor = new SKColor(180, 193, 199);
            var scoreTitleLabelSize = 0.1f * radius;
            var scoreTitleLabelY = cy + 0.37f * radius;
            DrawLabel(cx, scoreTitleLabelY, scoreTitle, scoreTitleLabelSize, scoreTitleLabelColor);

            var statisticDateLabelColor = new SKColor(0, 24, 47);
            var statisticDateLabelSize = 0.1f * radius + 2;
            var statisticDateLabelY = cy + 0.54f * radius;
            DrawLabel(cx, statisticDateLabelY, statisticDate, statisticDateLabelSize, statisticDateLabelColor);

            DrawPaintedCircle(radius, cx, cy, END_ANGLE, backgroundLineColor);
            DrawCircle(radius, cx, cy);

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
        private SKShader InitializeShader(float cx, float cy, float agileRotate)
        {
            var startColor = new SKColor(24, 109, 167);
            var endColor = new SKColor(255, 255, 255);
            var colors = new[] { startColor, endColor };
            //var colors2 = new[] { new SKColor(0, 107, 166), new SKColor(0, 169, 224), new SKColor(244, 244, 244) };
            var positions = new[] { 0.1f, 0.9f };
            var center = new SKPoint(cx, cy);
            SKMatrix matrix = new SKMatrix();
            SKMatrix.RotateDegrees(ref matrix, agileRotate, cx, cy);

            return SKShader.CreateSweepGradient(center, colors, null, matrix);
        }
        private void DrawLine(float _ballsCount, float lineWidth, SKColor lineColor, float upIndentFromCircle, float downIndentFromCircle)
        {

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
        public void DrawCircle(float radius, float cx, float cy)
        {
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 0.05f * radius,
                Color = new SKColor(255, 255, 255),
                IsAntialias = true,
            };

            var angle = COEFF_FOR_CALCULATE_SWEEP_ANGLE * _score + BEGIN_ANGLE - 6.1f;

            var smallCirceleCenterX = cx - (radius * (float)Math.Sin(angle * (Math.PI / 180f)));
            var smallCirceleCenterY = cy + (radius * (float)Math.Cos(angle * (Math.PI / 180f)));

            var radiusSmallCircle = 0.132f * radius;

            _canvas.DrawCircle(smallCirceleCenterX, smallCirceleCenterY, radiusSmallCircle, paint);

        }
        private void DrawPaintedCircle(float radius, float cx, float cy, float angleDegrees, SKColor paintedColor)
        {
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 1f,
                IsStroke = false,
                Color = paintedColor,
                IsAntialias = true,
            };
            var smallCirceleCenterX = CalculateCoordinateXPointOnCircle(radius, angleDegrees, cx);
            var smallCirceleCenterY = CalculateCoordinateYPointOnCircle(radius, angleDegrees, cy);

            var radiusSmallCircle = 0.11f * radius;

            _canvas.DrawCircle(smallCirceleCenterX, smallCirceleCenterY, radiusSmallCircle, paint);
        }
        private float CalculateCoordinateXPointOnCircle(float radius, float angleDegrees, float centerX)
        {
            return centerX - (radius * (float)Math.Sin(angleDegrees * (Math.PI / 180f)));
        }
        private float CalculateCoordinateYPointOnCircle(float radius, float angleDegrees, float centerY)
        {
            return centerY + (radius * (float)Math.Cos(angleDegrees * (Math.PI / 180f)));
        }
        private void CheakValidationScoreValue(float value)
        {
            if (value < MIN_VALUE_SCORE && value > MAX_VALUE_SCORE)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
