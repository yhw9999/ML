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

        
        internal override object GetDifferential(DataObject value, double[] weightArray)
        {
            return (double)Predict(value.Feature, weightArray) - Convert.ToDouble(value.Label.Label);
        }

        /// <summary>
        /// MethodOfLeastSquares
        /// </summary>
        /// <param name="value"></param>
        /// <param name="weightArray"></param>
        /// <returns></returns>
        internal override object GetTotalCost(double[] weightArray, DataSetObject dataSet)
        {
            double totalCost = 0;

            foreach (var item in dataSet.DataSet)
            {
                totalCost += Math.Pow((double)GetDifferential(item.Value, weightArray), 2);
            }

            totalCost /= 2 * dataSet.RowCount;

            return totalCost;
        }
    }
}
