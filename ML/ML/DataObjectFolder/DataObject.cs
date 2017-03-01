using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DataObjectFolder
{
    public class DataObject
    {
        private FeatureObject Feature;
        private LabelObject Label;

        internal void SetLabel(LabelObject labelObject)
        {
            Label = labelObject;
        }

        internal void SetFeature(FeatureObject featureObject)
        {
            Feature = featureObject;
        }
    }
}
