



using System;

namespace FlutterWave.Core
{
    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset ConvertToDateTimeOffSet(int totalSeconds) =>
            DateTimeOffset.FromUnixTimeSeconds(totalSeconds);
    }
}
