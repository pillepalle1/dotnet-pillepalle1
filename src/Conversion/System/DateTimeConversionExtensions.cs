using System;

namespace pillepalle1.Conversion.System
{
    public static class DateTimeConversionExtensions
    {
        private static readonly DateTime BaseDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Takes a unix timestamp (seconds since 1-Jan 1970) and converts it into a DateTime object
        /// </summary>
        public static DateTime AsUnixSecondsToDateTime(this long unixTime)
        {
            return BaseDate.AddSeconds(unixTime);
        }

        /// <summary>
        /// Takes a unix timestamp (milliseconds since 1-Jan 1970) and converts it into a DateTime object
        /// </summary>

        public static DateTime AsUnixMillisToDateTime(this long unixTime)
        {
            return BaseDate.AddMilliseconds(unixTime);
        }

        /// <summary>
        /// Takes a DateTime object and converts it into a unix timestamp (seconds since 1-Jan 1970)
        /// </summary>
        public static long ToUnixSeconds(this DateTime time)
        {
            return Convert.ToInt64(time.Subtract(BaseDate).TotalSeconds);
        }

        /// <summary>
        /// Takes a DateTime object and converts it into a unix timestamp (milliseconds since 1-Jan 1970)
        /// </summary>

        public static long ToUnixMillis(this DateTime time)
        {
            return Convert.ToInt64(time.Subtract(BaseDate).TotalMilliseconds);
        }
   }
}