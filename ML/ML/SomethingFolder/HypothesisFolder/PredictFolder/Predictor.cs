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

        public void SetCostFunction(ICostFunction costFunction)
        {
            _costFunction = costFunction;
        }

        internal object GetDifferential(DataObject value, double[] weightArray)
        {
            return _costFunction.GetDifferential(Predict(value.Feature, weightArray), value.Label);
        }
    }
}
