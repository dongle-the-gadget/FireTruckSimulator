using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace FTS
{
    public static class Position
    {
        public static Rect BoundsRelativeTo(this FrameworkElement element,
                                 FrameworkElement item)
        {
            return
              element.TransformToVisual(item)
                     .TransformBounds(LayoutInformation.GetLayoutSlot(element));
        }
    }
}
