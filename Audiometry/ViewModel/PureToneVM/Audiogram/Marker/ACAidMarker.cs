using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;
using OxyPlot;

namespace Audiometry.ViewModel.PureToneVM.Audiogram.Marker
{
    public static class ACAidMarker
    {
        public static ScreenPoint[] CreateCustomMarker(EarType earType, bool isNoResponse, bool addShift)
        {
            const double lowerLeftX = -0.75;
            const double lowerLeftY = 0.75;
            const double upperX = 0;
            const double upperY = -0.75;
            const double lowerRightX = 0.75;
            const double lowerRightY = 0.75;
            const double midRightX = 0.375;
            const double midRightY = 0;
            const double midLeftX = -0.375;
            const double midLeftY = 0;

            ScreenPoint lowerLeft = new ScreenPoint(lowerLeftX, lowerLeftY);
            ScreenPoint upper = new ScreenPoint(upperX, upperY);
            ScreenPoint lowerRight = new ScreenPoint(lowerRightX, lowerRightY);
            ScreenPoint midRight = new ScreenPoint(midRightX, midRightY);
            ScreenPoint midLeft = new ScreenPoint(midLeftX, midLeftY);

            List<ScreenPoint> marker = new List<ScreenPoint>();
            if (earType == EarType.RightEar)
            {
                marker.Add(lowerLeft);
                marker.Add(upper);
                marker.Add(lowerRight);
                marker.Add(midRight);
                marker.Add(midLeft);
                marker.Add(lowerLeft);
            }
            else if (earType == EarType.LeftEar)
            {
                marker.Add(lowerRight);
                marker.Add(upper);
                marker.Add(lowerLeft);
                marker.Add(midLeft);
                marker.Add(midRight);
                marker.Add(lowerRight);
            }
            else
            {
                throw new InvalidEnumArgumentException();
            }

            if (isNoResponse)
            {
                ArrowMarker.AddArrowToMarker(marker, earType, marker.Last().X, marker.Last().Y);
            }

            if (addShift)
            {
                ShiftMarker.AddShift(marker, earType);
            }

            return marker.ToArray();
        }
    }
}
