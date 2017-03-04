using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.DataObjectFolder;

namespace ML.SomethingFolder.HypothesisFolder.PredictFolder.CostFunctionFolder
{
    class MethodOfMaximumLikehood : ICostFunction
    {
        public object GetDifferential(object predict, LabelObject label)
        {
            throw new NotImplementedException();
        }

        public object GetTotalCost()
        {
            throw new NotImplementedException();
        }
    }
}
