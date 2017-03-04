using ML.DataObjectFolder;

namespace ML.SomethingFolder.HypothesisFolder.PredictFolder
{
    public abstract class Predictor
    {
        //protected ICostFunction _costFunction;

        abstract public object Predict(FeatureObject feature, double[] weightArray);

        abstract internal object GetDifferential(DataObject value, double[] weightArray);

        abstract internal object GetTotalCost(double[] weightArray, DataSetObject dataSet);
    }
}
