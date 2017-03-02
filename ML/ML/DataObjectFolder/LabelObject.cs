using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DataObjectFolder
{
    public class LabelObject
    {
        object _label;

        public LabelObject(object label)
        {
            Label = label;
        }

        public object Label
        {
            get
            {
                return _label;
            }

            set
            {
                _label = value;
            }
        }
    }
}
