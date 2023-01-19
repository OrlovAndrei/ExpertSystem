using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertSystem
{
    internal class LabelAttribute : Attribute
    {
        public string LabelText { get; set; }
        public string Symbol { get; set; }

        public LabelAttribute(string labelText, string symbol)
        {
            LabelText = labelText;
            Symbol = symbol;
        }
    }
}
