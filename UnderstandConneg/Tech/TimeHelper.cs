﻿using System;

namespace UnderstandConneg.Tech
{
    public static class TimeHelper
    {
        public static TimeSpan ToTimeSpan(this string time)
        {
            int hour = Int32.Parse(time.Substring(0, 2));
            int min = Int32.Parse(time.Substring(2, 2));

            return new TimeSpan(hour, min, 0);
        }
    }
}