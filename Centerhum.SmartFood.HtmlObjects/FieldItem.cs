using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centerhum.SmartFood.HtmlObjects.Enum;
using System.Web.Mvc;

namespace Centerhum.SmartFood.HtmlObjects
{
    public class FieldItem
    {
        public FieldItem()
        {
            this.Enable = true;            
        }

        /// <summary>
        /// Constructor for Any field type.
        /// </summary>
        /// <param name="name">Importante: Manter o mesmo nome da propriedade que você quer receber no POST.</param>
        public FieldItem(string name, string label, bool isRequired, FieldType type, string appendClass = "")
        {
            this.Name = name;
            this.Label = label;
            this.IsRequired = isRequired;
            this.Type = type;
            this.AppendClass = appendClass;
            this.Enable = true;
        }

        // Principal Properties
        /// <summary>
        /// Importante: Manter o mesmo nome da propriedade que você quer receber no POST.
        /// </summary>
        public string Name { get; set; }
        public string Label { get; set; }
        public string Placeholder { get; set; }
        public string HelpText { get; set; }
        public string Value { get; set; }
        public bool IsRequired { get; set; }
        public string AppendClass { get; set; }
        public bool Enable { get; set; }
        public FieldType Type { get; set; }
        

        // Private variables
        private TextAreaOptions _textAreaOptions;

        // Specific properties
        public IEnumerable<SelectListItem> SelectListItems { get; set; }
        public IEnumerable<RadioButtonItem> RadioButtonItems { get; set; }
        public IEnumerable<CheckedBoxItem> CheckedBoxItems { get; set; }
        public TextAreaOptions TextAreaOptions
        {
            get { return (_textAreaOptions == null) ? new TextAreaOptions() : _textAreaOptions; }
            set { _textAreaOptions = value; }
        }
        public AutoCompleteConfiguration AutoCompleteConfiguration 
        {
            get
            {
                if (_autoCompleteConfiguration == null)
                {
                    _autoCompleteConfiguration = new AutoCompleteConfiguration();
                }

                return _autoCompleteConfiguration;
            }

            set
            {                
                _autoCompleteConfiguration = value;
            }
        }
        private AutoCompleteConfiguration _autoCompleteConfiguration;
        
        public List<string> InitialsTags { get; set; }
    }
}