using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centerhum.SmartFood.HtmlObjects.Interfaces
{
    public interface IChartValue
    {
        List<Int32[]> Value { get; set; }
        String Label { get; set; }
    }
}
