using ML.SomethingFolder.HypothesisFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.SomethingFolder
{
    public enum KindOfSomething
    {
        Regression, Logistic
    }
    public class Something
    {
        Hypothesis _hypothesis;

        public Something(KindOfSomething kindOfSomething)
        {
            switch (kindOfSomething)
            {
                case KindOfSomething.Regression:

                    _hypothesis = new Hypothesis();

                    break;

                case KindOfSomething.Logistic:

                    break;

                default:

                    break;
            }
        }
    }
}
