using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;

namespace DesignableCanvas.Helpers
{
    public class MoveThumb : Thumb
    {
        public MoveThumb()
        {
            DragDelta += new DragDeltaEventHandler(MoveThumb_DragDelta);
        }

        void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var item = DataContext as Control;

            if (item == null) return;

            var left = Canvas.GetLeft(item);
            var top = Canvas.GetTop(item);

            Canvas.SetLeft(item, left + e.HorizontalChange);
            Canvas.SetTop(item, top + e.VerticalChange);
        }
    }
}
