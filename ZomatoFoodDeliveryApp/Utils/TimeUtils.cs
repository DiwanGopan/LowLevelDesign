using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomatoFoodDeliveryApp.Utils
{
    public static class TimeUtils
    {
        public static string GetCurrentTime()
        {
            return DateTime.Now.ToString(
                "ddd MMM dd HH:mm:ss yyyy",
                CultureInfo.InvariantCulture);
        }
    }
}
