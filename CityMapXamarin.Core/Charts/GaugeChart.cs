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

        private const float MIN_VALUE_SCORE = 0;
        private const float MAX_VALUE_SCORE = 100;

        private const float START_ARC_POINT_ANGLE = 60;
        private const float END_ARC_POINT_ANGLE = 300;

        private const int START_ARC_ANGLE = 150;
        private const int SWEEP_ARC_ANGLE = 240;
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
            var cx = width / 2f;
            var cy = height / 2f;

            if (_gaugeChartType == GaugeChartTypes.SectorGaugeChartWhithArrow)
            {
                var lineThickness = radius * 0.22f;
                DrawSectorGuageChartWithArrow(radius, cx, cy, START_ARC_ANGLE, lineThickness, _scoreTitle, _statisticDate);
            }
            else if (_gaugeChartType == GaugeChartTypes.GradientGaugeChartWhithoutArrow)
            {
                var lineThickness = radius / 8;
                DrawGradientGuageChartWithoutArrow(radius, cx, cy, START_ARC_ANGLE, _score, lineThickness, _statisticDate);
            }
            else if (_gaugeChartType == GaugeChartTypes.GradientGaugeChartWhithArrow)
            {
                var lineThickness = radius * 0.22f;
                DrawGradientGuageChartWithSmallCircle(radius, cx, cy, START_ARC_ANGLE, _score, lineThickness, _scoreTitle, _statisticDate);
            }

        }

        private void DrawSectorGuageChartWithArrow(float radius, float cx, float cy, float startAngle, float lineThickness, string scoreTitle, string statisticDate)
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
            var boldLineThickness = breakLineThickness * 0.3f;
            var thinLineThickness = boldLineThickness / 2f;


            var upIndentFromCircleForBreakLine = lineThickness / 2;
            var downIndentFromCircleForBreakLine = lineThickness / 2 + 10;

            var upIndentFromCircleForBoldLine = 0.07f * radius + lineThickness / 2; ;
            var downIndentFromCircleForrBoldLine = lineThickness / 2 + 0.07f * radius;

            var upIndentFromCircleForThinLine = 0f;
            var downIndentFromCircleFoThinLine = 0.33f * radius + lineThickness / 2;

            var scoreColor = new SKColor(0, 24, 47);
            var scoreValueLabelSize = 0.41f * radius;

            var scoreTitleLabelColor = new SKColor(180, 193, 199);
            var scoreTitleLabelSize = 0.1f * radius;
            var scoreTitleLabelY = cy + 0.37f * radius;

            var statisticDateLabelColor = new SKColor(0, 24, 47);
            var statisticDateLabelSize = 0.1f * radius + 2;
            var statisticDateLabelY = cy + 0.54f * radius;

            DrawArc(endSectorPaint, radius, cx, cy, startAngle, endSectorAngle);
            DrawArc(midleSectorPaint, radius, cx, cy, startAngle, midleSectorAngle);
            DrawArc(beginSectorPaint, radius, cx, cy, startAngle, beginSectorAngle);

            DrawPaintedCircleOnSpeedometer(radius, cx, cy, START_ARC_POINT_ANGLE, beginSectorColor);
            DrawPaintedCircleOnSpeedometer(radius, cx, cy, END_ARC_POINT_ANGLE, endSectorColor);

            DrawArrowSpeedometerLine(cx,cy,radius,_score, breakLineThickness, breakLineColor, upIndentFromCircleForBreakLine, downIndentFromCircleForBreakLine);
            DrawArrowSpeedometerLine(cx, cy, radius, _score, thinLineThickness, thinLineColor, upIndentFromCircleForThinLine, downIndentFromCircleFoThinLine);
            DrawArrowSpeedometerLine(cx, cy, radius, _score, boldLineThickness, boldLineColor, upIndentFromCircleForBoldLine, downIndentFromCircleForrBoldLine);

            DrawLabel(cx, cy, _score.ToString(), scoreValueLabelSize, scoreColor);
            DrawLabel(cx, scoreTitleLabelY, scoreTitle, scoreTitleLabelSize, scoreTitleLabelColor);
            DrawLabel(cx, statisticDateLabelY, statisticDate, statisticDateLabelSize, statisticDateLabelColor);

        }

        private void DrawGradientGuageChartWithoutArrow(float radius, float cx, float cy, float startAngle, float score, float lineThickness, string statisticDate = "")
        {
            var backgroundLineColor = new SKColor(241, 241, 241);
            var backgroundLinePaint = InitializePaint(lineThickness, backgroundLineColor);

            var gradientRotateAngle = 145f;
            var gradient = InitializeShader(cx, cy, gradientRotateAngle);
            var gradientLinePaint = InitializePaint(lineThickness, gradient);

            var scoreColor = new SKColor(0, 24, 47);
            var scoreValueLabelSize = radius / 2;

            DrawArc(backgroundLinePaint, radius, cx, cy, startAngle, SWEEP_ARC_ANGLE);
            DrawArc(gradientLinePaint, radius, cx, cy, startAngle, score * COEFF_FOR_CALCULATE_SWEEP_ANGLE);
            DrawLabel(cx, cy, score.ToString(), scoreValueLabelSize, scoreColor);

            if (!string.IsNullOrEmpty(statisticDate))
            {
                var statisticDateLabelColor = new SKColor(180, 193, 199);
                var statisticDateLabelSize = radius / 4;
                var statisticDateLabelY = cy + radius / 2;

                DrawLabel(cx, statisticDateLabelY, statisticDate, statisticDateLabelSize, statisticDateLabelColor);
            }
        }

        private void DrawGradientGuageChartWithSmallCircle(float radius, float cx, float cy, float startAngle, float score, float lineThickness, string scoreTitle, string statisticDate)
        {
            var backgroundLineColor = new SKColor(241, 241, 241);
            var backgroundLinePaint = InitializePaint(lineThickness, backgroundLineColor);

            var startColor = new SKColor(28, 114, 169);

            var gradientRotateAngle = 140f;
            var gradient = InitializeShader(cx, cy, gradientRotateAngle);
            var gradientLinePaint = InitializePaint(lineThickness, gradient);

            var scoreColor = new SKColor(0, 24, 47);
            var scoreValueLabelSize = 0.41f * radius;

            var scoreTitleLabelColor = new SKColor(180, 193, 199);
            var scoreTitleLabelSize = 0.1f * radius;
            var scoreTitleLabelY = cy + 0.37f * radius;

            var statisticDateLabelColor = new SKColor(0, 24, 47);
            var statisticDateLabelSize = 0.1f * radius + 2;
            var statisticDateLabelY = cy + 0.54f * radius;

            DrawPaintedCircleOnSpeedometer(radius, cx, cy, START_ARC_POINT_ANGLE, startColor);
            DrawArc(backgroundLinePaint, radius, cx, cy, startAngle, SWEEP_ARC_ANGLE);
            DrawArc(gradientLinePaint, radius, cx, cy, startAngle, score * COEFF_FOR_CALCULATE_SWEEP_ANGLE);

            DrawLabel(cx, cy, score.ToString(), scoreValueLabelSize, scoreColor);
            DrawLabel(cx, scoreTitleLabelY, scoreTitle, scoreTitleLabelSize, scoreTitleLabelColor);
            DrawLabel(cx, statisticDateLabelY, statisticDate, statisticDateLabelSize, statisticDateLabelColor);
            DrawPaintedCircleOnSpeedometer(radius, cx, cy, END_ARC_POINT_ANGLE, backgroundLineColor);
            DrawCircleOnSpeedometer(radius, cx, cy);
        }
        private void DrawArc(SKPaint paint, float radius, float cx, float cy, float startAngle, float sweepAngle)
        {
            using (SKPath path = new SKPath())
            {
                path.AddArc(SKRect.Create(cx - radius, cy - radius, 2 * radius, 2 * radius), startAngle, sweepAngle);
                _canvas.DrawPath(path, paint);
            }
        }


        private void DrawArrowSpeedometerLine(float cx, float cy, float radius, float score, float lineThickness, SKColor lineColor, float upIndentFromCircle, float downIndentFromCircle)
        {
            var angle = COEFF_FOR_CALCULATE_SWEEP_ANGLE * score + START_ARC_POINT_ANGLE;
            var x1 = CalculateCoordinateXPointOnCircle(radius - downIndentFromCircle, angle, cx);
            var y1 = CalculateCoordinateYPointOnCircle(radius - downIndentFromCircle, angle, cy);

            var x2 = CalculateCoordinateXPointOnCircle(radius + downIndentFromCircle, angle, cx);
            var y2 = CalculateCoordinateYPointOnCircle(radius + downIndentFromCircle, angle, cy);

            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = lineThickness,
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
        public void DrawCircleOnSpeedometer(float radius, float cx, float cy)
        {
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 0.05f * radius,
                Color = new SKColor(255, 255, 255),
                IsAntialias = true,
            };

            var angle = COEFF_FOR_CALCULATE_SWEEP_ANGLE * _score + START_ARC_POINT_ANGLE - 6.1f;

            var smallCircleCenterX = CalculateCoordinateYPointOnCircle(radius, angle, cx); ;
            var smallCircleCenterY = CalculateCoordinateYPointOnCircle(radius, angle, cy); ;

            var radiusSmallCircle = 0.132f * radius;

            _canvas.DrawCircle(smallCircleCenterX, smallCircleCenterY, radiusSmallCircle, paint);

        }
        private void DrawPaintedCircleOnSpeedometer(float radius, float cx, float cy, float angleDegrees, SKColor paintedColor)
        {
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 1f,
                IsStroke = false,
                Color = paintedColor,
                IsAntialias = true,
            };
            var smallCircleCenterX = CalculateCoordinateXPointOnCircle(radius, angleDegrees, cx);
            var smallCircleCenterY = CalculateCoordinateYPointOnCircle(radius, angleDegrees, cy);

            var radiusSmallCircle = 0.11f * radius;

            _canvas.DrawCircle(smallCircleCenterX, smallCircleCenterY, radiusSmallCircle, paint);
        }

        private SKPaint InitializePaint(float lineThickness, SKColor color)
        {
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = lineThickness,
                Color = color,
                IsAntialias = true
            };
            return paint;
        }

        private SKPaint InitializePaint(float lineThickness, SKShader shader)
        {
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = lineThickness,
                Shader = shader,
                IsAntialias = true
            };
            return paint;
        }
        private SKShader InitializeShader(float cx, float cy, float angleRotate)
        {
            var startColor = new SKColor(24, 109, 167);
            var endColor = new SKColor(255, 255, 255);
            var colors = new[] { startColor, endColor };
            var center = new SKPoint(cx, cy);

            SKMatrix matrix = new SKMatrix();
            SKMatrix.RotateDegrees(ref matrix, angleRotate, cx, cy);

            return SKShader.CreateSweepGradient(center, colors, null, matrix);
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
