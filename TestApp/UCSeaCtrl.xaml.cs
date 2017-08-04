using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestApp
{
    public partial class UCSeaCtrl : UserControl
    {
        public UCSeaCtrl()
        {
            InitializeComponent();
            this.init();
        }

        public void init()
        {
            for (int i = 0; i < main_grid.RowDefinitions.Count(); i++)
            {
                var ctrl = (FrameworkElement)main_grid.Children[i];
                var _pathGeometry = (PathGeometry)((Path)ctrl).Data;
                double rotate_angle = -45;

                PathFigure _pathFigure = (PathFigure)_pathGeometry.Figures[0];
                PathSegmentCollection _pathSegmentCollection = _pathFigure.Segments;
                var index = i + 5;
                double init_end_figure_point_X = Math.Ceiling(500.0 / index);
                if (i == 1 || i == 3||i==7)
                    rotate_angle = -55;
                for (int j = 1; j <= 7; j++)
                {
                    _pathFigure.Segments.Add(new ArcSegment()
                    {
                        Size = new Size(50, 25),
                        RotationAngle = rotate_angle,
                        SweepDirection = SweepDirection.Clockwise,
                        IsLargeArc = true,
                        Point = new Point(init_end_figure_point_X, _pathFigure.StartPoint.Y)
                    }
                    );

                    init_end_figure_point_X = init_end_figure_point_X += 100;
                }
            }
        }
    }
}
