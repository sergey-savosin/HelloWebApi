using System;
using System.ComponentModel;
using UnderstandConneg.Tech;

namespace UnderstandConneg.Model
{
    [TypeConverter(typeof(ShiftTypeConverter))]
    public class Shift
    {
        public DateTime Date { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }
    }
}