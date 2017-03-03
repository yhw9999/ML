using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ML.Draw
{
    interface IDraw
    {
        void DrawCostGraph(Grid grid, Canvas canvas, List<double> History);
        void DrawWeightGraph(Grid grid_CostGrid, Canvas canvas_WeightGraph, List<double[]> weightHistory);
        void SetXAxis(Grid grid, int totalTrainCount);
        void SetYAxis(Grid grid, double maxValue, double minValue);
        void DrawOnCanvas(Grid grid, Canvas canvas, List<List<double>> values, double maxValue, double minValue, int valueCount);
        List<double> DivideValue(List<double> history, int dividingAmount);
    }
}
