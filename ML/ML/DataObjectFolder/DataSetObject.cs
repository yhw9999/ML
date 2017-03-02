using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.DataObjectFolder
{
    public class DataSetObject
    {
        int _rowCount = 0;
        int _featureCount = 0;

        public Dictionary<int, DataObject> DataSet = new Dictionary<int, DataObject>();

        public int RowCount
        {
            get
            {
                return _rowCount;
            }

            set
            {
                _rowCount = value;
            }
        }

        public int FeatureCount
        {
            get
            {
                return _featureCount;
            }

            set
            {
                _featureCount = value;
            }
        }

        public DataSetObject(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);

            while (!sr.EndOfStream)
            {
                DataObject tmpData = new DataObject();

                string row = sr.ReadLine();

                string[] tmpArray = row.Split(',');

                double[] features = new double[tmpArray.Length - 1];

                for (int i = 0; i < tmpArray.Length; i++)
                {
                    if (i != tmpArray.Length-1)
                    {
                        features[i] = double.Parse(tmpArray[i]);
                    }
                    else
                    {
                        tmpData.SetLabel(new LabelObject(tmpArray[i]));
                    }

                    tmpData.SetFeature(new FeatureObject(features));
                }

                DataSet.Add(RowCount, tmpData);

                RowCount++;
            }

            FeatureCount = DataSet[0].GetFueatureCount();
        }
    }
}
