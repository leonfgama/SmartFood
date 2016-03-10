using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centerhum.SmartFood.HtmlObjects.Enum;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class XaxisSettings
    {
        public int Max { get; set; }
        public int Min { get; set; }
        public XaxisModes Mode { get; set; }
        public List<XaxisTick> XaxisTicks { get; set; }
        public List<string> MonthNames { get; set; }
        public int TickLength { get; set; }
    }
}
