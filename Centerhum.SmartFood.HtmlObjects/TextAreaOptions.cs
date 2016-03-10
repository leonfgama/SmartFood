using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centerhum.SmartFood.HtmlObjects
{
    /// <summary>
    /// Default value for MaxLegth is 250 and CreateAutoHelpText is True.
    /// Need instance class for default values.
    /// </summary>
    public class TextAreaOptions
    {
        public TextAreaOptions()
        {
            MaxLength = 250;
            CreateAutoHelpText = true;
        }

        public int MaxLength { get; set; }
        public bool CreateAutoHelpText { get; set; }
    }
}