using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centerhum.SmartFood.HtmlObjects.Interfaces;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class Chart
    {
        public Chart()
        {
            if (this.ChartValue == null)
                this.ChartValue = new List<IChartValue>();
        }

        public string Title { get; set; }

        public ChartSettings Settings { get; set; }
        public List<IChartValue> ChartValue { get; set; }
    }
}
