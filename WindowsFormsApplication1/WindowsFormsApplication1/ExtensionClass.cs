using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public static class Int32Extension
    {
        public static string FormatForMoney(this int Value)
        {
            return Value.ToString("$###,###,###,##0");
        }

        public static string FormatForDate(this int Value)
        {
            return Value.ToString("0000/00/00");
        }
    }

    public static class DoubleExtension
    {
        public static string FormatPercent(this double Value)
        {
            return Value.ToString("0.00%");
        }
    }
}
