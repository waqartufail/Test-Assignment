using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Utilities
{
    public static class TimeUnit
    {
        public static TimeSpan Seconds(int value) => TimeSpan.FromSeconds(value);
        public static TimeSpan Minutes(int value) => TimeSpan.FromMinutes(value);
        public static TimeSpan Hours(int value) => TimeSpan.FromHours(value);
        public static TimeSpan Days(int value) => TimeSpan.FromDays(value);

        public static int ToSeconds(TimeSpan timeSpan) => (int)timeSpan.TotalSeconds;
        public static int ToMinutes(TimeSpan timeSpan) => (int)timeSpan.TotalMinutes;
        public static int ToHours(TimeSpan timeSpan) => (int)timeSpan.TotalHours;
        public static int ToDays(TimeSpan timeSpan) => (int)timeSpan.TotalDays;
    }

}
