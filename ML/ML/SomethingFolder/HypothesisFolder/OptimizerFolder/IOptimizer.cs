using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.DataObjectFolder;
using ML.SomethingFolder.HypothesisFolder.PredictFolder;

namespace ML.SomethingFolder.HypothesisFolder.OptimizerFolder
{
    public interface IOptimizer
    {
        void Train(Predictor predictor, double[] weightArray, DataSetObject dataSet, double learningRate);
    }
}
