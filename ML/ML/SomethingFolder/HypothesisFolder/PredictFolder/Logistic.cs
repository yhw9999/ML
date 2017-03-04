using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.DataObjectFolder;

namespace ML.SomethingFolder.HypothesisFolder.PredictFolder
{
    public class Logistic : Predictor
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

            return 1 / (1 + Math.Exp(-result));
        }

        internal override object GetDifferential(DataObject value, double[] weightArray)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// MethodOfMaximumLikehood
        /// </summary>
        /// <param name="weightArray"></param>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        internal override object GetTotalCost(double[] weightArray, DataSetObject dataSet)
        {
            double totalCost = 0;

            foreach (var item in dataSet.DataSet)
            {
                FeatureObject tmpFeature = item.Value.Feature;

                double predictResult = (double)Predict(tmpFeature, weightArray);
                double label = (double)item.Value.Label.Label;

                totalCost += label * Math.Log10(predictResult) - (1 - label) * Math.Log(1 - predictResult);
            }

            totalCost /= dataSet.RowCount;

            return totalCost;
        }
    }
}
