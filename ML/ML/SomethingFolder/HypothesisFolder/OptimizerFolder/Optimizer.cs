using ML.SomethingFolder.HypothesisFolder.PredictFolder.CostFunctionFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.DataObjectFolder;
using ML.SomethingFolder.HypothesisFolder.PredictFolder;

namespace ML.SomethingFolder.HypothesisFolder.OptimizerFolder
{
    public class Optimizer
    {
        double _learningRate = 0;

        IOptimizer _optimizer = null;
        ICostFunction _costFunction = null;

        public void SetLearningRate(double learningRate)
        {
            _learningRate = learningRate;
        }

        public void SetOptimizer(IOptimizer optimizer)
        {
            _optimizer = optimizer;
        }

        public void SetCostFunction(ICostFunction costFunction)
        {
            _costFunction = costFunction;
        }

        internal void Train(Predictor predictor, double[] weightArray, DataSetObject dataSet)
        {
            _optimizer.Train(predictor, weightArray, dataSet, _learningRate);
        }
    }
}
