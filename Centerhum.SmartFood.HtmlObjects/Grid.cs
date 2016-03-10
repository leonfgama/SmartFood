using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class Grid
    {
        public Grid()
        {

        }
        
        public string Title { get; set; }
        public bool OrganizeGrid { get; set; }
        public string UrlDeleteSelecteds { get; set; }
        public Options Options { get; set; }
        public List<HeaderColumn> HeaderColumns { get; set; }

        /// <summary>
        /// Caso você esteja trabalhando com Entity, transforme sua entidade em um DataSet, utilizando a classe de Conversor do Chubb.Brasil.Data.DataHelper.Conversor.
        /// </summary>
        public DataSet DataSetValue { get; set; }
        public GridStyle Style { get; set; }
    }
}
