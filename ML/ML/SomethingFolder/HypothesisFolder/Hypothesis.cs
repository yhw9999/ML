using ML.SomethingFolder.HypothesisFolder.OptimizerFolder;
using ML.SomethingFolder.HypothesisFolder.PredictFolder;
using System;
using System.Collections.Generic;
using ML.DataObjectFolder;
using ML.SomethingFolder.HypothesisFolder.HistoryFolder;

namespace ML.SomethingFolder.HypothesisFolder
{
    public class Hypothesis
    {
        double[] _weightArray;

        History _costHistory;
        History _weightHistory;

        Random random;

        Predictor _predictor =null;
        Optimizer _optimizer = null;

        public double[] WeightArray
        {
            get
            {
                return _weightArray;
            }

            set
            {
                _weightArray = value;
            }
        }

        public Hypothesis(Predictor predictor, IOptimizer optimizer, double learningRate)
        {
            _costHistory = new History ();
            _weightHistory = new History();

            _predictor = predictor;

            _optimizer = new Optimizer();
            _optimizer.SetLearningRate(learningRate);
            _optimizer.SetOptimizer(optimizer);
        }

        public void InitWeightArray(int featureCount)
        {
            random = new Random();

            WeightArray = new double[featureCount];

            for (int i = 0; i < featureCount; i++)
            {
                WeightArray[i] = random.NextDouble();
            }
        }

        internal List<T> GetWeightHistory<T>()
        {
            return _weightHistory.GetHistory<T>();
        }

        internal List<T> GetCostHistory<T>()
        {
            return _costHistory.GetHistory<T>();
        }

        internal object Predict(FeatureObject feature)
        {
            return _predictor.Predict(feature, WeightArray);
        }

        internal void Train(DataSetObject dataSet)
        {
            _optimizer.Train(_predictor, WeightArray, dataSet);

            _weightHistory.RecordHistory((double[])WeightArray.Clone());
            _costHistory.RecordHistory(_predictor.GetTotalCost(WeightArray, dataSet));
        }
    }
}