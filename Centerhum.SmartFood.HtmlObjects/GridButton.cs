using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class GridButton
    {
        public string Icon { get; set; }
        public string ToolTipText { get; set; }
        public string Id { get; set; }
        public string AppendClass { get; set; }
        public string UrlAction { get; set; }


        public string DataColumnShow { get; set; }        

        public bool ConfirmModal { get; set; }

        /// <summary>
        /// Usar string format para passar o valor da primary key.
        /// Exemplo: Deseja reprocessar o {0}?
        /// </summary>
        public string MessageConfirmModal { get; set; }
    }
}
