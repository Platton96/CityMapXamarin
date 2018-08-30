﻿using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityMapXamarin.Core.Charts
{
    public class GaugeChart : Chart
    {
        private float _score;
        private GaugeChartTypes _gaugeChartType;
        private string _scoreTitle;
        private string _statisticDate;
        private static class GuageChartDefines
        {
            public const float MIN_VALUE_SCORE = 0;
            public const float MAX_VALUE_SCORE = 100;

            public const float START_ARC_POINT_ANGLE = 60;
            public const float END_ARC_POINT_ANGLE = 300;

            public const float START_ARC_ANGLE = 150;
            public const float SWEEP_ARC_ANGLE = 240;

            public const float COEFF_FOR_CALCULATE_SWEEP_ANGLE = SWEEP_ARC_ANGLE / MAX_VALUE_SCORE;
            public const float COEF_FOR_CALCULATE_RADIUS = 0.4f;

            public static class SectorGaugeChart
            {
                public const float BEGIN_SECTOR_SWEEP_ANGLE = 60;
                public const float MIDLE_SECTOR_SWEEP_ANGLE = 180;
                public const float END_SECTOR_SWEEP_ANGLE = 240;

                public static class CoefForCalculate
                {
                    public const float ARC_LINE_THICKNESS = 0.22f;

                    public const float BREAK_LINE_THICKNESS = 0.09f;
                    public const float BOLD_LINE_THICKNESS = 0.3f;
                    public const float THIN_LINE_THICKNESS = 0.5f;

                    public const float UP_INDENT_FROM_CIRCLE_FOR_BREAK_LINE = 0.5f;
                    public const float DOWN_INDENT_FROM_CIRCLE_FOR_BREAK_LINE = 0.6f;

                    public const float UP_INDENT_FROM_CIRCLE_FOR_BOLD_LINE = 0.07f;
                    public const float DOWN_INDENT_FROM_CIRCLE_FOR_BOLD_LINE = 0.07f;

                    public const float DOWN_INDENT_FROM_CIRCLE_FOR_LINE_THICKNESS = 0.33f;

                    public const float SCORE_VALUE_LABEL_SIZE = 0.51f;
                    public const float SCORE_TITLE_LABEL_SIZE = 0.12f;
                    public const float STATISTIC_DATE_LABEL_SIZE = 2;

                    public const float SCORE_TITLE_LABEL_Y = 0.37f;
                    public const float STATISTIC_DATE_LABEL_Y = 0.54f;
                }
            }

            public static class GradientGaugeChartWhithArrow
            {
                public const float GRADIENT_ROTATE_ANGLE = 140;
                public static class CoefForCalculate
                {
                    public const float ARC_LINE_THICKNESS = 0.22f;

                    public const float SCORE_VALUE_LABEL_SIZE = 0.51f;
                    public const float SCORE_TITLE_LABEL_SIZE = 0.12f;
                    public const float STATISTIC_DATE_LABEL_SIZE = 2;

                    public const float SCORE_TITLE_LABEL_Y = 0.37f;
                    public const float STATISTIC_DATE_LABEL_Y = 0.54f;
                }
            }
            public static class GradientGaugeChartWhithoutArrow
            {
                public const float GRADIENT_ROTATE_ANGLE = 145;
                public static class CoefForCalculate
                {
                    public const float ARC_LINE_THICKNESS = 0.22f;

                    public const float SCORE_VALUE_LABEL_SIZE = 0.63f;
                    public const float STATISTIC_DATE_LABEL_SIZE = 0.31f;

                    public const float STATISTIC_DATE_LABEL_Y = 0.5f;
                }
            }

        }
        private SKCanvas _canvas;

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
            var radius = Math.Min(width, height) * GuageChartDefines.COEF_FOR_CALCULATE_RADIUS;
            var cx = width / 2f;
            var cy = height / 2f;

            if (_gaugeChartType == GaugeChartTypes.SectorGaugeChartWhithArrow)
            {
                var lineThickness = radius * GuageChartDefines.SectorGaugeChart.CoefForCalculate.ARC_LINE_THICKNESS;
                DrawSectorGuageChartWithArrow(radius, cx, cy, GuageChartDefines.START_ARC_ANGLE, lineThickness, _scoreTitle, _statisticDate);
            }
            else if (_gaugeChartType == GaugeChartTypes.GradientGaugeChartWhithoutArrow)
            {
                var lineThickness = radius / 8;
                DrawGradientGuageChartWithoutArrow(radius, cx, cy, GuageChartDefines.START_ARC_ANGLE, _score, lineThickness, _statisticDate);
            }
            else if (_gaugeChartType == GaugeChartTypes.GradientGaugeChartWhithArrow)
            {
                var lineThickness = radius * 0.22f;
                DrawGradientGuageChartWithSmallCircle(radius, cx, cy, GuageChartDefines.START_ARC_ANGLE, _score, lineThickness, _scoreTitle, _statisticDate);
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

            var scoreColor = new SKColor(0, 24, 47);
            var scoreTitleLabelColor = new SKColor(180, 193, 199);
            var statisticDateLabelColor = new SKColor(0, 24, 47);

            var beginSectorPaint = InitializePaint(lineThickness, beginSectorColor);
            var midleSectorPaint = InitializePaint(lineThickness, midleSectorColor);
            var endSectorPaint = InitializePaint(lineThickness, endSectorColor);

            var breakLineThickness = 0.09f * radius;
            var boldLineThickness = breakLineThickness * 0.3f;
            var thinLineThickness = boldLineThickness / 2f;

            var upIndentFromCircleForBreakLine = lineThickness / 2;
            var downIndentFromCircleForBreakLine = lineThickness * 0.6f;

            var upIndentFromCircleForBoldLine = 0.07f * radius + lineThickness / 2; ;
            var downIndentFromCircleForrBoldLine = lineThickness / 2 + 0.07f * radius;

            var upIndentFromCircleForThinLine = 0f;
            var downIndentFromCircleFoThinLine = 0.33f * radius + lineThickness / 2;

            var scoreValueLabelSize = 0.51f * radius;
            var scoreTitleLabelSize = 0.12f * radius;
            var statisticDateLabelSize = scoreTitleLabelSize + 2;

            var scoreTitleLabelY = cy + 0.37f * radius;
            var statisticDateLabelY = cy + 0.54f * radius;

            DrawArc(endSectorPaint, radius, cx, cy, startAngle, GuageChartDefines.SectorGaugeChart.END_SECTOR_SWEEP_ANGLE);
            DrawArc(midleSectorPaint, radius, cx, cy, startAngle, GuageChartDefines.SectorGaugeChart.MIDLE_SECTOR_SWEEP_ANGLE);
            DrawArc(beginSectorPaint, radius, cx, cy, startAngle, GuageChartDefines.SectorGaugeChart.BEGIN_SECTOR_SWEEP_ANGLE);

            DrawPaintedCircleOnSpeedometer(radius, cx, cy, GuageChartDefines.START_ARC_POINT_ANGLE, beginSectorColor);
            DrawPaintedCircleOnSpeedometer(radius, cx, cy, GuageChartDefines.END_ARC_POINT_ANGLE, endSectorColor);

            DrawArrowSpeedometerLine(cx, cy, radius, _score, breakLineThickness, breakLineColor, upIndentFromCircleForBreakLine, downIndentFromCircleForBreakLine);
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
            var gradient = InitializeShader(cx, cy, gradientRotateAngle,null);
            var gradientLinePaint = InitializePaint(lineThickness, gradient);

            var scoreColor = new SKColor(0, 24, 47);
            var scoreValueLabelSize = radius / 2;

            DrawArc(backgroundLinePaint, radius, cx, cy, startAngle, GuageChartDefines.SWEEP_ARC_ANGLE);
            DrawArc(gradientLinePaint, radius, cx, cy, startAngle, score * GuageChartDefines.COEFF_FOR_CALCULATE_SWEEP_ANGLE);
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

            var startColor = new SKColor(28, 114, 169);

            var scoreColor = new SKColor(0, 24, 47);
            var scoreTitleLabelColor = new SKColor(180, 193, 199);
            var statisticDateLabelColor = new SKColor(0, 24, 47);

            var backgroundLinePaint = InitializePaint(lineThickness, backgroundLineColor);

            var gradientRotateAngle = 145f;
            var gradientColors = GetGradientColor(score);
            var gradient = InitializeShader(cx, cy, gradientRotateAngle, gradientColors);
            var gradientLinePaint = InitializePaint(lineThickness, gradient);

            var scoreValueLabelSize = 0.7f * radius;

            var scoreTitleLabelSize = 0.3f * radius;
            var scoreTitleLabelY = cy + 0.37f * radius;

            var statisticDateLabelSize = 0.3f * radius + 2;
            var statisticDateLabelY = cy + 0.54f * radius;

            var scoreAngle = GuageChartDefines.COEFF_FOR_CALCULATE_SWEEP_ANGLE * score + GuageChartDefines.START_ARC_POINT_ANGLE ;

         
            DrawArc(backgroundLinePaint, radius, cx, cy, startAngle, GuageChartDefines.SWEEP_ARC_ANGLE);
            DrawArc(gradientLinePaint, radius, cx, cy, startAngle, score * GuageChartDefines.COEFF_FOR_CALCULATE_SWEEP_ANGLE);

            DrawLabel(cx, cy, score.ToString(), scoreValueLabelSize, scoreColor);
            DrawLabel(cx, scoreTitleLabelY, scoreTitle, scoreTitleLabelSize, scoreTitleLabelColor);
            DrawLabel(cx, statisticDateLabelY, statisticDate, statisticDateLabelSize, statisticDateLabelColor);
            DrawPaintedCircleOnSpeedometer(radius, cx, cy, GuageChartDefines.START_ARC_POINT_ANGLE, gradientColors.FirstOrDefault());
            DrawPaintedCircleOnSpeedometer(radius, cx, cy, scoreAngle, gradientColors.LastOrDefault());
            DrawPaintedCircleOnSpeedometer(radius, cx, cy, GuageChartDefines.END_ARC_POINT_ANGLE, backgroundLineColor);
            DrawCircleOnSpeedometer(radius, cx, cy);
        }

        //private void DrawGradientGuageChartWithSmallCircle2(float radius, float cx, float cy, float startAngle, float score, float lineThickness, string scoreTitle, string statisticDate)
        //{
        //    var backgroundLineColor = new SKColor(241, 241, 241);

        //    var startColor = new SKColor(28, 114, 169);

        //    var scoreColor = new SKColor(0, 24, 47);
        //    var scoreTitleLabelColor = new SKColor(180, 193, 199);
        //    var statisticDateLabelColor = new SKColor(0, 24, 47);

        //    var backgroundLinePaint = InitializePaint(lineThickness, backgroundLineColor);

        //    var gradientRotateAngle = 140f;
        //    var gradient = InitializeShader(cx, cy, gradientRotateAngle);
        //    var gradientLinePaint = InitializePaint(lineThickness, gradient);

        //    var scoreValueLabelSize = 0.41f * radius;

        //    var scoreTitleLabelSize = 0.1f * radius;
        //    var scoreTitleLabelY = cy + 0.37f * radius;

        //    var statisticDateLabelSize = 0.1f * radius + 2;
        //    var statisticDateLabelY = cy + 0.54f * radius;

        //    DrawPaintedCircleOnSpeedometer(radius, cx, cy, GuageChartDefines.START_ARC_POINT_ANGLE, startColor);
        //    DrawArc(backgroundLinePaint, radius, cx, cy, startAngle, GuageChartDefines.SWEEP_ARC_ANGLE);
        //    DrawArc(gradientLinePaint, radius, cx, cy, startAngle, score * GuageChartDefines.COEFF_FOR_CALCULATE_SWEEP_ANGLE);

        //    DrawLabel(cx, cy, score.ToString(), scoreValueLabelSize, scoreColor);
        //    DrawLabel(cx, scoreTitleLabelY, scoreTitle, scoreTitleLabelSize, scoreTitleLabelColor);
        //    DrawLabel(cx, statisticDateLabelY, statisticDate, statisticDateLabelSize, statisticDateLabelColor);
        //    DrawPaintedCircleOnSpeedometer(radius, cx, cy, GuageChartDefines.END_ARC_POINT_ANGLE, backgroundLineColor);
        //    DrawCircleOnSpeedometer(radius, cx, cy);
        //}
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
            var angle = GuageChartDefines.COEFF_FOR_CALCULATE_SWEEP_ANGLE * score + GuageChartDefines.START_ARC_POINT_ANGLE;
            var x1 = CalculateCoordinateXPointOnCircle(radius - downIndentFromCircle, angle, cx);
            var y1 = CalculateCoordinateYPointOnCircle(radius - downIndentFromCircle, angle, cy);

            var x2 = CalculateCoordinateXPointOnCircle(radius + upIndentFromCircle, angle, cx);
            var y2 = CalculateCoordinateYPointOnCircle(radius + upIndentFromCircle, angle, cy);

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
                StrokeWidth = 0.013f * radius,
                Color = new SKColor(255, 255, 255),
                IsAntialias = true,
            };

            var angle = GuageChartDefines.COEFF_FOR_CALCULATE_SWEEP_ANGLE * _score + GuageChartDefines.START_ARC_POINT_ANGLE;

            var smallCircleCenterX = CalculateCoordinateXPointOnCircle(radius, angle, cx); ;
            var smallCircleCenterY = CalculateCoordinateYPointOnCircle(radius, angle, cy); ;

            var radiusSmallCircle = 0.11f * radius;

            _canvas.DrawCircle(smallCircleCenterX, smallCircleCenterY, radiusSmallCircle, paint);

        }
        private void DrawPaintedCircleOnSpeedometer(float radius, float cx, float cy, float angleDegrees, SKColor paintedColor)
        {
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
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
        private SKShader InitializeShader(float cx, float cy, float angleRotate, SKColor[] colors)
        {
            var center = new SKPoint(cx, cy);

            SKMatrix matrix = new SKMatrix();
            SKMatrix.RotateDegrees(ref matrix, angleRotate, cx, cy);
            var colPosition = new[] { 0, 0.03f, 0.25f, 0.5f, 0.75f, 1 };
            return SKShader.CreateSweepGradient(center, colors, colPosition, matrix);
        }
        private SKColor[] GetGradientColor(float score)
        {
            var redColor = SKColor.Parse("#FD462B");
            var orangeColor = SKColor.Parse("#FFB81C");
            var yelowColor = SKColor.Parse("#FFEA1C");
            var greenColor = SKColor.Parse("#00B16A");

            var colors0To24 = new[] { redColor, redColor, redColor, redColor, redColor, redColor };
            var colors25To49 = new[] { redColor,redColor, orangeColor, orangeColor, orangeColor, orangeColor};
            var colors50To100 = new[] {yelowColor, yelowColor, greenColor, greenColor, greenColor, greenColor };
            
            if (score>=0&&score<25)
            {
                return colors0To24;
            }
            else if (score >= 25 && score < 50)
            {
                return colors25To49;
            }
            else if (score >= 50 && score <= 100)
            {
                return colors50To100;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
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
            if (value < GuageChartDefines.MIN_VALUE_SCORE && value > GuageChartDefines.MAX_VALUE_SCORE)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
