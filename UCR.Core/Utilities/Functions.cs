﻿using System;

namespace HidWizards.UCR.Core.Utilities
{
    public static class Functions
    {
        public static long ApplyRangeDeadZone(long value, int deadZonePercentage)
        {
            var gap = (deadZonePercentage / 100.0) * Constants.AxisMaxValue;
            var remainder = Constants.AxisMaxValue - gap;
            var gapPercent = Math.Max(0, Math.Abs(value) - gap) / remainder;
            return (long)(gapPercent * Constants.AxisMaxValue * Math.Sign(value));
        }

        public static long ApplyRangeSensitivity(long value, int sensitivity, bool linear)
        {
            var sensitivityPercent = (sensitivity / 100.0);
            if (linear) return (long)(value * sensitivityPercent);
            // TODO https://github.com/evilC/UCR/blob/master/Libraries/StickOps/StickOps.ahk#L60
            return value;
        }
    }
}
