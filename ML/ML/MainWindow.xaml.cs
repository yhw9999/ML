using Microsoft.Win32;
using ML.DataObjectFolder;
using ML.SomethingFolder;
using System;
using System.Windows;

namespace ML
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSetObject _dataSet = null;

        Something _something = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Data initialize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SetData_Click(object sender, RoutedEventArgs e)
        {
            string filePath = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;

                _dataSet = new DataSetObject(filePath);
            }

            _something = new Something((KindOfSomething)Enum.Parse(typeof(KindOfSomething), comboBox_Filter.Text)
                , double.Parse(textBox_LearningRate.Text), _dataSet.GetFeatureCount());
        }

        private void button_train_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Predict_Click(object sender, RoutedEventArgs e)
        {
            textBlock_Predict.Text = _something.Predict(_dataSet.DataSet[0].Feature).ToString();
        }
    }
}
