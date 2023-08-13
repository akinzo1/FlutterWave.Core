



using System;

namespace FlutterWave.Core
{
    public interface IDateTimeBroker
    {
        DateTimeOffset ConvertToDateTimeOffSet(int totalSeconds);
    }
}
