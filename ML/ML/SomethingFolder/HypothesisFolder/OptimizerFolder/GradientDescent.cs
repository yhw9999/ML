using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.DataObjectFolder;
using ML.SomethingFolder.HypothesisFolder.PredictFolder;

namespace ML.SomethingFolder.HypothesisFolder.OptimizerFolder
{
    public class GradientDescent : IOptimizer
    {
        public void Train(Predictor predictor, double[] weightArray, DataSetObject dataSet, double learningRate)
        {
            int weightCount = weightArray.Length;

            double[] tmpWeightArray = new double[weightCount];

            foreach (var item in dataSet.DataSet)
            {
                DataObject data = item.Value;

                double DifferentialPerRow = (double)predictor.GetDifferential(item.Value, weightArray);

                double[] tmpFeature = data.Feature.GetFeature();

                for (int i = 0; i < weightCount; i++)
                {
                    tmpWeightArray[i] += DifferentialPerRow * tmpFeature[i];
                }
            }

            for (int i = 0; i < weightCount; i++)
            {
                weightArray[i] -= (tmpWeightArray[i]/ dataSet.RowCount) * learningRate;
            }
        }
    }
}
