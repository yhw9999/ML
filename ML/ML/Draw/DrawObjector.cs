using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ML.Draw
{
    public class DrawObjector : IDraw
    {
        int _dividingAmount = 500;

        public int DivideAcount { get => _dividingAmount; set => _dividingAmount = value; }

        /// <summary>
        /// 일정 비율로 나눔
        /// </summary>
        /// <param name="history"></param>
        /// <param name="maxCost"></param>
        /// <param name="minCost"></param>
        /// <param name="dividingAmount"></param>
        /// <returns></returns>
        public List<double> DivideValue(List<double> history, int dividingAmount)
        {
            List<double> result = new List<double>();

            int indexGap = history.Count / dividingAmount;

            for (int i = 0; i < dividingAmount; i++)
            {
                result.Add(history[indexGap * i]);
            }

            return result;
        }

        public void DrawWeightGraph(Grid grid, Canvas canvas, List<double[]> History)
        {
            grid.Children.Clear();

            List<List<double>> weightList = new List<List<double>>();
            List<List<double>> values = new List<List<double>>();

            int totalTrainCount = History.Count;

            double maxWeight = 0;
            double minWeight = 0;

            foreach (double[] item in History)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] < minWeight)
                    {
                        minWeight = item[i];
                    }
                    else if (item[i] > maxWeight)
                    {
                        maxWeight = item[i];
                    }
                }
            }

            weightList = HistotyConvert(History);

            foreach (List<double> item in weightList)
            {
                List<double> value = DivideValue(item, _dividingAmount);
                values.Add(value);
            }

            DrawOnCanvas(grid, canvas, values, maxWeight, minWeight, _dividingAmount);
            SetYAxis(grid, maxWeight, minWeight);
            SetXAxis(grid, totalTrainCount);
        }

        private List<List<double>> HistotyConvert(List<double[]> history)
        {
            List<List<double>> result = new List<List<double>>();

            int featureAmount = history[0].Length;

            for (int i = 0; i < featureAmount; i++)
            {
                result.Add(new List<double>());
            }

            foreach (double[] item in history)
            {
                for (int i = 0; i < featureAmount; i++)
                {
                    result[i].Add(item[i]);
                }
            }

            return result;
        }

        public void DrawCostGraph(Grid grid, Canvas canvas, List<double> History)
        {
            grid.Children.Clear();

            List<List<double>> values = new List<List<double>>();

            int totalTrainCount = History.Count;

            double maxCost = History[0];
            double minCost = History[totalTrainCount - 1];

            List<double> value = DivideValue(History, _dividingAmount);


            values.Add(value);

            DrawOnCanvas(grid, canvas, values, maxCost, minCost, _dividingAmount);
            SetYAxis(grid, maxCost, minCost);
            SetXAxis(grid, totalTrainCount);
        }

        public void DrawOnCanvas(Grid grid, Canvas canvas, List<List<double>> values, double maxValue, double minValue, int valueCount)
        {
            List<Line> lineList = new List<Line>();

            int index = 1;

            canvas.Children.Clear();

            double canvasHeight = canvas.ActualHeight;

            double gap = (maxValue - minValue) / valueCount;

            double xAxisGap = canvas.ActualWidth / valueCount;
            double yAxisGap = canvas.ActualHeight / valueCount;

            foreach (var item in values)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    double tmpSize = item[i] / gap;

                    if (i != valueCount - 1)
                    {
                        double nextSize = item[i + 1] / gap;

                        Line tmpLine = new Line()
                        {
                            X1 = xAxisGap * i,
                            Y1 = canvasHeight - (yAxisGap * tmpSize),
                            X2 = xAxisGap * (i + 1),
                            Y2 = canvasHeight - ((yAxisGap * nextSize)),
                            Stroke = Brushes.Black,
                            StrokeThickness = 1.5
                        };

                        lineList.Add(tmpLine);
                    }
                    else
                    {
                        Line tmpLine = new Line()
                        {
                            X1 = xAxisGap * i,
                            Y1 = yAxisGap * tmpSize,
                            X2 = (xAxisGap * (i + 1)),
                            Y2 = (yAxisGap * tmpSize),
                            Stroke = Brushes.Black,
                            StrokeThickness = 1.5
                        };

                        lineList.Add(tmpLine);
                    }
                }
            }

            foreach (Line item in lineList)
            {
                canvas.Children.Add(item);
            }

            Grid.SetColumn(canvas, 1);
            Grid.SetRow(canvas, 0);

            grid.Children.Add(canvas);
        }

        public void SetXAxis(Grid grid, int totalTrainCount)
        {
            TextBlock xMax = new TextBlock() { Name = "textBloc_xMax", Text = totalTrainCount.ToString(), VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Right };
            TextBlock xMin = new TextBlock() { Name = "textBloc_xMin", Text = 0.ToString(), VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Left };

            Grid.SetColumn(xMax, 1);
            Grid.SetColumn(xMin, 1);
            Grid.SetRow(xMax, 1);
            Grid.SetRow(xMin, 1);

            grid.Children.Add(xMax);
            grid.Children.Add(xMin);
        }

        public void SetYAxis(Grid grid, double maxValue, double minValue)
        {
            TextBlock yMax = new TextBlock() { Name = "textBloc_yMax", Text = ((int)maxValue).ToString(), VerticalAlignment = VerticalAlignment.Top, HorizontalAlignment = HorizontalAlignment.Center };
            TextBlock yMin = new TextBlock() { Name = "textBloc_yMin", Text = ((int)minValue).ToString(), VerticalAlignment = VerticalAlignment.Bottom, HorizontalAlignment = HorizontalAlignment.Center };

            Grid.SetColumn(yMax, 0);
            Grid.SetColumn(yMin, 0);
            Grid.SetRow(yMax, 0);
            Grid.SetRow(yMin, 0);

            grid.Children.Add(yMax);
            grid.Children.Add(yMin);
        }


    }
}
