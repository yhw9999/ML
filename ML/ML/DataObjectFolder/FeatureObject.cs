using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DataObjectFolder
{
    public class FeatureObject
    {
        double[] Features;

        public FeatureObject(double[] features)
        {
            Features = features;
        }

        internal int FeatureCount()
        {
            return Features.Length;
        }

        internal double[] GetFeature()
        {
            return Features;
        }
    }
}
