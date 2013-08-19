using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace DesignableCanvas.Helpers
{
    class RotateThumb : Thumb
    {
        ContentControl _designerItem;
        Canvas _designerCanvas;
        Point _centrePoint;
        Vector _startVector;
        RotateTransform _rotateTransform;
        double _initialAngle;

        public RotateThumb()
        {
            DragStarted += new DragStartedEventHandler(RotateThumb_DragStarted);
            DragDelta += new DragDeltaEventHandler(RotateThumb_DragDelta);
        }

        void RotateThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            _designerItem = DataContext as ContentControl;

            if (_designerItem == null) return;

            _designerCanvas = VisualTreeHelper.GetParent(_designerItem) as Canvas;

            if (_designerCanvas == null) return;

            _centrePoint = _designerItem.TranslatePoint(new Point(_designerItem.Width * _designerItem.RenderTransformOrigin.X,
                _designerItem.Height * _designerItem.RenderTransformOrigin.Y), _designerCanvas);

            var startPoint = Mouse.GetPosition(_designerCanvas);
            _startVector = Point.Subtract(startPoint, _centrePoint);

            _rotateTransform = _designerItem.RenderTransform as RotateTransform;
            if (_rotateTransform == null)
            {
                _designerItem.RenderTransform = new RotateTransform(0);
                _initialAngle = 0;
            }
            else
            {
                _initialAngle = _rotateTransform.Angle;
            }
        }

        void RotateThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (_designerItem != null && _designerCanvas != null)
            {
                var currentPoint = Mouse.GetPosition(_designerCanvas);
                Vector deltaVector = Point.Subtract(currentPoint, _centrePoint);

                var angle = Vector.AngleBetween(_startVector, deltaVector);

                var rotateTransform = _designerItem.RenderTransform as RotateTransform;
                rotateTransform.Angle = _initialAngle + Math.Round(angle, 0);
                _designerItem.InvalidateMeasure();
            }
        }
    }
}
