using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.DataObjectFolder;

namespace ML.SomethingFolder.HypothesisFolder.PredictFolder
{
    public class Regression : Predictor
    {
        public override object Predict(FeatureObject feature, double[] weightArray)
        {
            double result = 0;

            double[] features = feature.GetFeature();

            //multiply feature by weight
            for (int i = 0; i < weightArray.Length; i++)
            {
                result += features[i] * weightArray[i];
            }

            return result;
        }
    }
}
