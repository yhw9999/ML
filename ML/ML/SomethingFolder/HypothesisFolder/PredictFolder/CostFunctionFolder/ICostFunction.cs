using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.DataObjectFolder;

namespace ML.SomethingFolder.HypothesisFolder.PredictFolder.CostFunctionFolder
{
    public interface ICostFunction
    {
        object GetTotalCost();
        object GetDifferential(object predict, LabelObject label);
    }
}
