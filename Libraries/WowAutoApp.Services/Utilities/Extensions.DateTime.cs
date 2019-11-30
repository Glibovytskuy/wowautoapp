using System;

namespace WowAutoApp.Services.Utilities
{
    public static partial class Extensions
    {
        /// <summary>
        /// Number of seconds that have elapsed since 00:00:00 Coordinated Universal Time (UTC), Thursday, 1 January 1970
        /// </summary>
        /// <param name="dateTime">Indput date time to be converted to unix time stamp</param>
        /// <returns>Number of seconds that have elapsed since 00:00:00 Coordinated Universal Time (UTC), Thursday, 1 January 1970 till dateTime</returns>
        public static long ToUnixTimeStamp(this DateTime dateTime)
        {
            var offset = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var universalTime = dateTime.ToUniversalTime();

            var delta = Math.Round((universalTime - offset).TotalSeconds);
            return (long)delta;
        }

        public static DateTime ConvertToUserTime(this DateTime dt, DateTimeKind sourceDateTimeKind)
        {
            dt = DateTime.SpecifyKind(dt, sourceDateTimeKind);
            if (sourceDateTimeKind == DateTimeKind.Local && TimeZoneInfo.Local.IsInvalidTime(dt))
                return dt;

            //TODO Get customer\user current time zone
            //var currentUserTimeZoneInfo = CurrentTimeZone;
            return TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.Utc);
        }

        public static string ToSafeFileName(this DateTime dateTime)
        {
            return $"{dateTime.Day.ToString("00")}{dateTime.Month.ToString("00")}{dateTime.Year}";
        }
    }
}