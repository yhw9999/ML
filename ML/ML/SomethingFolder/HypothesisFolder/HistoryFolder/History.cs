using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.DataObjectFolder;
using ML.SomethingFolder.HypothesisFolder.PredictFolder;

namespace ML.SomethingFolder.HypothesisFolder.HistoryFolder
{
    public class History
    {
        List<object> _history = new List<object>();

        public void RecordHistory(object record)
        {
            _history.Add(record);
        }

        internal List<T> GetHistory<T>()
        {
            return _history.Cast<T>().ToList();
        }
    }
}
