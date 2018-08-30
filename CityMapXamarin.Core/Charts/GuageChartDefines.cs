using System;
using System.Collections.Generic;
using System.Text;

namespace CityMapXamarin.Core.Charts
{
    public static class GuageChartDefines
    {
        public const float MIN_VALUE_SCORE = 0;
        public const float MAX_VALUE_SCORE = 100;

        public const float START_ARC_POINT_ANGLE = 60;
        public const float END_ARC_POINT_ANGLE = 300;

        public const float START_ARC_ANGLE = 150;
        public const float SWEEP_ARC_ANGLE = 240;

        public const float COEFF_FOR_CALCULATE_SWEEP_ANGLE = 2.4f;
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
}
