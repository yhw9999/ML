using ML.DataObjectFolder;
using ML.SomethingFolder.HypothesisFolder.PredictFolder;

namespace ML.SomethingFolder.HypothesisFolder.OptimizerFolder
{
    public class Optimizer
    {
        double _learningRate = 0;

        IOptimizer _optimizer = null;

        public void SetLearningRate(double learningRate)
        {
            _learningRate = learningRate;
        }

        public void SetOptimizer(IOptimizer optimizer)
        {
            _optimizer = optimizer;
        }

        internal void Train(Predictor predictor, double[] weightArray, DataSetObject dataSet)
        {
            _optimizer.Train(predictor, weightArray, dataSet, _learningRate);
        }
    }
}
