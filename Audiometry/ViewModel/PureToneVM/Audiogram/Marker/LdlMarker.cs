using System.Collections.Generic;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;
using OxyPlot;

namespace Audiometry.ViewModel.PureToneVM.Audiogram.Marker
{
    public static class LdlMarker
    {
        public static ScreenPoint[] CreateCustomMarker(EarType earType, bool isNoResponse, bool addShift)
        {
            const double lBottomX = 0.5;
            const double lTopY = 0.75;

            List<ScreenPoint> marker = new List<ScreenPoint>();
            ScreenPoint topLeft = new ScreenPoint(-lBottomX, -lTopY);
            ScreenPoint bottomLeft = new ScreenPoint(-lBottomX, lTopY);
            ScreenPoint bottomRight = new ScreenPoint(lBottomX, lTopY);
            marker.Add(bottomRight);
            marker.Add(bottomLeft);
            marker.Add(topLeft);
            marker.Add(bottomLeft);
            marker.Add(bottomRight);

            if (isNoResponse)
            {
                ArrowMarker.AddArrowToMarker(marker, earType, bottomRight.X, bottomRight.Y);
            }

            if (addShift)
            {
                ShiftMarker.AddShift(marker, earType);
            }

            return marker.ToArray();
        }
    }
}
