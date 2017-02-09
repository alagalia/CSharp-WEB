using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Cookie
    {
       
        public Cookie(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public Cookie() : this(null, null)
        {
            
        }

        public string Name { get; private set; }

        public string Value { get; private set; }

        public override string ToString()
        {
            
            return $"{this.Name}={this.Value}";
        }
    }
}
