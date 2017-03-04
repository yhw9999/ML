using ML.SomethingFolder.HypothesisFolder;
using ML.SomethingFolder.HypothesisFolder.OptimizerFolder;
using ML.SomethingFolder.HypothesisFolder.PredictFolder;
using ML.SomethingFolder.HypothesisFolder.PredictFolder.CostFunctionFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.DataObjectFolder;

namespace ML.SomethingFolder
{
    public enum KindOfSomething
    {
        Regression, Logistic
    }
    public class Something
    {
        Hypothesis _hypothesis;

        public Something(KindOfSomething kindOfSomething, double learningRate, int featureCount)
        {
            switch (kindOfSomething)
            {
                case KindOfSomething.Regression:

                    _hypothesis = new Hypothesis(new Regression(), new MethodOfLeastSquares(), new GradientDescent(), learningRate);

                    _hypothesis.InitWeightArray(featureCount);

                    break;

                case KindOfSomething.Logistic:

                    _hypothesis = new Hypothesis(new Logistic(), new MethodOfLeastSquares(), new GradientDescent(), learningRate);

                    _hypothesis.InitWeightArray(featureCount);

                    break;

                default:

                    break;
            }
        }

        internal object Predict(FeatureObject feature)
        {
            return _hypothesis.Predict(feature);
        }

        internal void Train(DataSetObject dataSet)
        {
            _hypothesis.Train(dataSet);
        }

        internal double[] GetWeight()
        {
            return _hypothesis.WeightArray;
        }

        internal List<T> GetCostHistory<T>()
        {
            return _hypothesis.GetCostHistory<T>();
        }

        internal List<T> GetWeightHistory<T>()
        {
            return _hypothesis.GetWeightHistory<T>();

        }
    }
}
