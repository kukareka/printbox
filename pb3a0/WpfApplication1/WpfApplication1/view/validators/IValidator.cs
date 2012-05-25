using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    interface IValidator
    {
        public bool IsValid(string data);
    }
}
