using System;
using System.Collections.Generic;
using System.ComponentModel;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;
using OxyPlot;

namespace Audiometry.ViewModel.PureToneVM.Audiogram.Marker
{
    public static class ACUmskMarker
    {
        public static MarkerType GetDefaultMarker(EarType earType)
        {
            if (earType == EarType.RightEar)
            {
                return MarkerType.Circle;
            }
            else if (earType == EarType.LeftEar)
            {
                return MarkerType.Cross;
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
                double radius = 1;
                double arrowTailAngleRad = Math.PI/2;
                double arrowTailX = radius*Math.Cos(arrowTailAngleRad);
                double arrowTailY = radius*Math.Sin(arrowTailAngleRad);
                double numOfPoints = 50;
                double angleInc = 2*Math.PI/numOfPoints;

                for (int i = 0; i <= numOfPoints; i++)
                {
                    double angleRad = arrowTailAngleRad + (angleInc*i);
                    marker.Add(new ScreenPoint(radius*Math.Cos(angleRad), radius*Math.Sin(angleRad)));
                }
                
                ArrowMarker.AddArrowToMarker(marker, earType, arrowTailX, arrowTailY);
            }
            else if (earType == EarType.LeftEar)
            {
                double arrowTailX = 1;
                double arrowTailY = 1;
                ScreenPoint bottomRight = new ScreenPoint(arrowTailX, arrowTailY);
                ScreenPoint center = new ScreenPoint(0, 0);
                ScreenPoint topRight = new ScreenPoint(arrowTailX, -arrowTailY);
                ScreenPoint bottomLeft = new ScreenPoint(-arrowTailX, arrowTailY);
                ScreenPoint topLeft = new ScreenPoint(-arrowTailX, -arrowTailY);
                marker.Add(bottomRight);
                marker.Add(center);
                marker.Add(topRight);
                marker.Add(bottomLeft);
                marker.Add(center);
                marker.Add(topLeft);
                marker.Add(bottomRight);

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
