using System.Collections.Generic;
using System.ComponentModel;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;
using OxyPlot;

namespace Audiometry.ViewModel.PureToneVM.Audiogram.Marker
{
    public static class ACMskMarker
    {
        public static MarkerType GetDefaultMarker(EarType earType)
        {
            if (earType == EarType.RightEar)
            {
                return MarkerType.Triangle;
            }
            else if (earType == EarType.LeftEar)
            {
                return MarkerType.Square;
            }
            else
            {
                throw new InvalidEnumArgumentException();
            }
        }

        public static ScreenPoint[] CreateCustomMarkerWithArrow(EarType earType)
        {
            List<ScreenPoint> marker = new List<ScreenPoint>();

            if (earType == EarType.RightEar)
            {
                double arrowTailX = -1;
                double arrowTailY = 0.5;
                ScreenPoint left = new ScreenPoint(-1, 0.5);
                ScreenPoint right = new ScreenPoint(1, 0.5);
                ScreenPoint top = new ScreenPoint(0, -1);
                marker.Add(left);
                marker.Add(top);
                marker.Add(right);
                marker.Add(left);
                ArrowMarker.AddArrowToMarker(marker, earType, arrowTailX, arrowTailY);
            }
            else if (earType == EarType.LeftEar)
            {
                double arrowTailX = 1;
                double arrowTailY = 1;
                ScreenPoint rightBottom = new ScreenPoint(arrowTailX, arrowTailY);
                ScreenPoint rightTop = new ScreenPoint(arrowTailX, -arrowTailY);
                ScreenPoint leftTop = new ScreenPoint(-arrowTailX, -arrowTailY);
                ScreenPoint leftBottom = new ScreenPoint(-arrowTailX, arrowTailY);
                marker.Add(rightBottom);
                marker.Add(rightTop);
                marker.Add(leftTop);
                marker.Add(leftBottom);
                marker.Add(rightBottom);
                ArrowMarker.AddArrowToMarker(marker, earType, arrowTailX, arrowTailY);
            }
            else
            {
                throw new InvalidEnumArgumentException();
            }

            return marker.ToArray();
        }
    }
}
