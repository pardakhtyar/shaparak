using System;

namespace PardakhtYar.Shaparak {

    internal static class TimeStampHelper {

        private static readonly DateTime _epoch = 
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Convert a <see cref="DateTime"/> value to correspondig Unix Timestamp.
        /// Note that you must send DateTime value in UTC for this method to work correctly.
        /// </summary>
        /// <param name="value">DateTime value to convert to Timestamp.</param>
        /// <returns>Unix Timestamp for the given <see cref="DateTime"/> value.</returns>
        public static long ToUnixTimestamp(this DateTime value) 
            => (long)(value.ToUniversalTime().Subtract(_epoch)).TotalSeconds;
        

        /// <summary>
        /// Correspondig Unix Timestamp for UTC Now.
        /// </summary>
        /// <returns>Unix Timestamp for UTC Now</returns>
        public static long UnixTimestampNow(this DateTime ignored) 
            => DateTime.UtcNow.ToUnixTimestamp();

        /// <summary>
        /// Converts given Unix Timestamp to correspondig DateTime.
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimestampToDateTime(this long timeStamp) 
            => _epoch.AddSeconds(timeStamp).ToLocalTime();
        
    }
}
