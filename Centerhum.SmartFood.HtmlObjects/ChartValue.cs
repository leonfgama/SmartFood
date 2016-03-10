using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centerhum.SmartFood.HtmlObjects.Interfaces;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class ChartValue : IChartValue
    {
        /// <summary>
        /// [0] = Position
        /// [1] = Value
        /// </summary>
        public List<Int32[]> Value { get; set; }
        public string Label { get; set; }
    }
}
