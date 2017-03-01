using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SomethingFolder.HypothesisFolder.PredictFolder.CostFunctionFolder
{
    public interface ICostFunction
    {
        double GetTotalCost();
        double GetDifferential();
    }
}
