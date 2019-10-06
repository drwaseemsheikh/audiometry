using System.Collections.Generic;
using System.ComponentModel;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;
using OxyPlot;

namespace Audiometry.ViewModel.PureToneVM.Audiogram.Marker
{
    public static class BCMskMarker
    {
        public static ScreenPoint[] CreateCustomMarker(EarType earType, bool isNoResponse)
        {
            const double topRightX = 0.75;
            const double topRightY = -1;
            const double topLeftX = -0.25;
            const double topLeftY = topRightY;
            const double bottomLeftX = topLeftX;
            const double bottomLeftY = -topLeftY;
            const double bottomRightX = topRightX;
            const double bottomRightY = bottomLeftY;

            List<ScreenPoint> marker = new List<ScreenPoint>();

            if (earType == EarType.RightEar)
            {
                ScreenPoint topRight = new ScreenPoint(topRightX, topRightY);
                ScreenPoint topLeft = new ScreenPoint(topLeftX, topLeftY);
                ScreenPoint bottomLeft = new ScreenPoint(bottomLeftX, bottomLeftY);
                ScreenPoint bottomRight = new ScreenPoint(bottomRightX, bottomRightY);
                marker.Add(bottomLeft);
                marker.Add(topLeft);
                marker.Add(topRight);
                marker.Add(topLeft);
                marker.Add(bottomLeft);
                marker.Add(bottomRight);
                marker.Add(bottomLeft);

                if (isNoResponse)
                {
                    ArrowMarker.AddArrowToMarker(marker, earType, bottomLeft.X, bottomLeft.Y);
                }
            }
            else if (earType == EarType.LeftEar)
            {
                ScreenPoint topLeft = new ScreenPoint(-topRightX, topRightY);
                ScreenPoint topRight = new ScreenPoint(-topLeftX, topLeftY);
                ScreenPoint bottomRight = new ScreenPoint(-bottomLeftX, bottomLeftY);
                ScreenPoint bottomLeft = new ScreenPoint(-bottomRightX, bottomRightY);
                marker.Add(bottomRight);
                marker.Add(topRight);
                marker.Add(topLeft);
                marker.Add(topRight);
                marker.Add(bottomRight);
                marker.Add(bottomLeft);
                marker.Add(bottomRight);

                if (isNoResponse)
                {
                    ArrowMarker.AddArrowToMarker(marker, earType, bottomRight.X, bottomRight.Y);
                }
            }
            else
            {
                throw new InvalidEnumArgumentException();
            }

            return marker.ToArray();
        }
    }
}
