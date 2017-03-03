using ML.SomethingFolder.HypothesisFolder.PredictFolder.CostFunctionFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.SomethingFolder.HypothesisFolder.OptimizerFolder;
using ML.DataObjectFolder;

namespace ML.SomethingFolder.HypothesisFolder.PredictFolder
{
    public abstract class Predictor
    {
        protected ICostFunction _costFunction;

        abstract public object Predict(FeatureObject feature, double[] weightArray);

        abstract internal object GetDifferential(DataObject value, double[] weightArray);

        abstract internal object GetTotalCost(double[] weightArray, DataSetObject dataSet);

        public void SetCostFunction(ICostFunction costFunction)
        {
            _costFunction = costFunction;
        }

    }
}
