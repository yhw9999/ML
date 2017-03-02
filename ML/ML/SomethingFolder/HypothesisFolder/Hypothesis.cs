using ML.SomethingFolder.HypothesisFolder.OptimizerFolder;
using ML.SomethingFolder.HypothesisFolder.PredictFolder;
using ML.SomethingFolder.HypothesisFolder.PredictFolder.CostFunctionFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SomethingFolder.HypothesisFolder
{
    public class Hypothesis
    {
        double[] _weightArray;

        Random random;

        Predictor _predictor =null;
        Optimizer _optimizer = null;

        public Hypothesis(Predictor predictor, ICostFunction costFunction , IOptimizer optimizer, double learningRate)
        {
            _predictor = predictor;
            _predictor.SetCostFunction(costFunction);

            _optimizer = new Optimizer();
            _optimizer.SetLearningRate(learningRate);
            _optimizer.SetOptimizer(optimizer);
            _optimizer.SetCostFunction(costFunction);
        }

        public void InitWeightArray(int featureCount)
        {
            random = new Random();

            _weightArray = new double[featureCount];

            for (int i = 0; i < featureCount; i++)
            {
                _weightArray[i] = random.NextDouble();
            }
        }
    }
}