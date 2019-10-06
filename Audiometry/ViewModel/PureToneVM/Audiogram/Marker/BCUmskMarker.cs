using System;
using System.Collections.Generic;
using System.ComponentModel;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;
using OxyPlot;

namespace Audiometry.ViewModel.PureToneVM.Audiogram.Marker
{
    public static class BCUmskMarker
    {
        public static ScreenPoint[] CreateCustomMarker(EarType earType, bool addArrow)
        {
            double radius = Math.Sqrt(2);
            double angleRad = 7 * Math.PI / 4;
            double shift = radius/2;
            double topRightX = radius * Math.Cos(angleRad) - shift;
            double topRightY = radius * Math.Sin(angleRad);
            double midX = -shift;
            double midY = 0;
            double bottomRightX = topRightX;
            double bottomRightY = -topRightY;

            List<ScreenPoint> marker = new List<ScreenPoint>();

            if (earType == EarType.RightEar)
            {
                ScreenPoint bottomRight = new ScreenPoint(bottomRightX, bottomRightY);
                ScreenPoint mid = new ScreenPoint(midX, midY);
                ScreenPoint topRight = new ScreenPoint(topRightX, topRightY);
                marker.Add(bottomRight);
                marker.Add(mid);
                marker.Add(topRight);
                marker.Add(mid);
                marker.Add(bottomRight);
               
                if (addArrow)
                {
                    ArrowMarker.AddArrowToMarker(marker, earType, bottomRightX, bottomRightY);
                }
            }
            else if (earType == EarType.LeftEar)
            {
                ScreenPoint bottomLeft = new ScreenPoint(-bottomRightX, bottomRightY);
                ScreenPoint mid = new ScreenPoint(-midX, midY);
                ScreenPoint topLeft = new ScreenPoint(-topRightX, topRightY);
                marker.Add(bottomLeft);
                marker.Add(mid);
                marker.Add(topLeft);
                marker.Add(mid);
                marker.Add(bottomLeft);

                if (addArrow)
                {
                    ArrowMarker.AddArrowToMarker(marker, earType, -bottomRightX, bottomRightY);
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
