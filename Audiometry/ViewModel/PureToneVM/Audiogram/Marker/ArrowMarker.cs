using System;
using System.Collections.Generic;
using System.ComponentModel;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;
using OxyPlot;

namespace Audiometry.ViewModel.PureToneVM.Audiogram.Marker
{
    public static class ArrowMarker
    {
        public static void AddArrowToMarker(List<ScreenPoint> marker, EarType earType, double arrowTailX, double arrowTailY)
        {
            const double arrowTailLength = 1.5;
            const double arrowTailAngleRad = 45 * Math.PI / 180;
            const double arrowEarDistance = 0.75;
            const double arrowEarAngleRad = 20 * Math.PI / 180;

            if (earType == EarType.RightEar)
            {
                double arrowTipX = arrowTailX - (arrowTailLength * Math.Cos(arrowTailAngleRad));
                double arrowTipY = arrowTailY + (arrowTailLength * Math.Sin(arrowTailAngleRad));
                double arrowUpperEarX = arrowTailX - (arrowEarDistance * Math.Cos(arrowEarAngleRad));
                double arrowUpperEarY = arrowTailY + (arrowEarDistance * Math.Sin(arrowEarAngleRad));
                double arrowLowerEarX = arrowTailX - (arrowEarDistance * Math.Cos(2 * arrowTailAngleRad - arrowEarAngleRad));
                double arrowLowerEarY = arrowTailY + (arrowEarDistance * Math.Sin(2 * arrowTailAngleRad - arrowEarAngleRad));
                marker.Add(new ScreenPoint(arrowTipX, arrowTipY));
                marker.Add(new ScreenPoint(arrowUpperEarX, arrowUpperEarY));
                marker.Add(new ScreenPoint(arrowTipX, arrowTipY));
                marker.Add(new ScreenPoint(arrowLowerEarX, arrowLowerEarY));
                marker.Add(new ScreenPoint(arrowTipX, arrowTipY));
                marker.Add(new ScreenPoint(arrowTailX, arrowTailY));
            }
            else if (earType == EarType.LeftEar)
            {
                double arrowTipX = arrowTailX + (arrowTailLength * Math.Cos(arrowTailAngleRad));
                double arrowTipY = arrowTailY + (arrowTailLength * Math.Sin(arrowTailAngleRad));
                double arrowUpperEarX = arrowTailX + (arrowEarDistance * Math.Cos(arrowEarAngleRad));
                double arrowUpperEarY = arrowTailY + (arrowEarDistance * Math.Sin(arrowEarAngleRad));
                double arrowLowerEarX = arrowTailX + (arrowEarDistance * Math.Cos(2 * arrowTailAngleRad - arrowEarAngleRad));
                double arrowLowerEarY = arrowTailY + (arrowEarDistance * Math.Sin(2 * arrowTailAngleRad - arrowEarAngleRad));
                marker.Add(new ScreenPoint(arrowTipX, arrowTipY));
                marker.Add(new ScreenPoint(arrowUpperEarX, arrowUpperEarY));
                marker.Add(new ScreenPoint(arrowTipX, arrowTipY));
                marker.Add(new ScreenPoint(arrowLowerEarX, arrowLowerEarY));
                marker.Add(new ScreenPoint(arrowTipX, arrowTipY));
                marker.Add(new ScreenPoint(arrowTailX, arrowTailY));
            }
            else
            {
                throw new InvalidEnumArgumentException();
            }
        }
    }
}
