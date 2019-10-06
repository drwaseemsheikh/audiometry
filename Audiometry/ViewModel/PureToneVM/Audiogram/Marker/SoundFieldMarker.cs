using System;
using System.Collections.Generic;
using System.Linq;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;
using OxyPlot;

namespace Audiometry.ViewModel.PureToneVM.Audiogram.Marker
{
    public static class SoundFieldMarker
    {
        public static ScreenPoint[] CreateCustomMarker(EarType earType, bool isNoResponse, bool addShift)
        {
            const double a = 0.5;
            const double b = 0.375;

            List<AGPoint> sUpperUpperHalf = new List<AGPoint>();
            sUpperUpperHalf.Add(new AGPoint(0.5, 0));
            sUpperUpperHalf.Add(new AGPoint(0.3, 0));
            sUpperUpperHalf.Add(new AGPoint(0.1, 0));
            sUpperUpperHalf.Add(new AGPoint(-0.1, 0));
            sUpperUpperHalf.Add(new AGPoint(-0.3, 0));
            sUpperUpperHalf.Add(new AGPoint(-0.5, 0));

            int i = 0;
            for (; i < sUpperUpperHalf.Count; i++)
            {
                sUpperUpperHalf[i].Y = -b - Math.Sqrt(Math.Pow(b, 2) - Math.Pow((b * sUpperUpperHalf[i].X / a), 2));
            }

            List<AGPoint> sUpperLowerHalf = new List<AGPoint>();
            sUpperLowerHalf.Add(new AGPoint(-0.5, 0));
            sUpperLowerHalf.Add(new AGPoint(-0.3, 0));
            sUpperLowerHalf.Add(new AGPoint(-0.1, 0));
            sUpperLowerHalf.Add(new AGPoint(0, 0));

            for (i = 0; i < sUpperLowerHalf.Count; i++)
            {
                sUpperLowerHalf[i].Y = -b + Math.Sqrt(Math.Pow(b, 2) - Math.Pow((b * sUpperLowerHalf[i].X / a), 2));
            }

            List<AGPoint> sLowerUpperHalf = new List<AGPoint>();
            sLowerUpperHalf.Add(new AGPoint(0.1, 0));
            sLowerUpperHalf.Add(new AGPoint(0.3, 0));
            sLowerUpperHalf.Add(new AGPoint(0.5, 0));

            for (i = 0; i < sLowerUpperHalf.Count; i++)
            {
                sLowerUpperHalf[i].Y = b - Math.Sqrt(Math.Pow(b, 2) - Math.Pow((b * sLowerUpperHalf[i].X / a), 2));
            }

            List<AGPoint> sLowerLowerHalf = new List<AGPoint>();
            sLowerLowerHalf.Add(new AGPoint(0.5, 0));
            sLowerLowerHalf.Add(new AGPoint(0.3, 0));
            sLowerLowerHalf.Add(new AGPoint(0.1, 0));
            sLowerLowerHalf.Add(new AGPoint(-0.1, 0));
            sLowerLowerHalf.Add(new AGPoint(-0.3, 0));
            sLowerLowerHalf.Add(new AGPoint(-0.5, 0));

            for (i = 0; i < sLowerLowerHalf.Count; i++)
            {
                sLowerLowerHalf[i].Y = b + Math.Sqrt(Math.Pow(b, 2) - Math.Pow((b * sLowerLowerHalf[i].X / a), 2));
            }

            List<ScreenPoint> marker = new List<ScreenPoint>();
            for (i = sLowerLowerHalf.Count - 2; i >= 0; i--)
            {
                marker.Add(new ScreenPoint(sLowerLowerHalf[i].X, sLowerLowerHalf[i].Y));
            }

            for (i = sLowerUpperHalf.Count - 1; i >= 0; i--)
            {
                marker.Add(new ScreenPoint(sLowerUpperHalf[i].X, sLowerUpperHalf[i].Y));
            }

            for (i = sUpperLowerHalf.Count - 1; i >= 0; i--)
            {
                marker.Add(new ScreenPoint(sUpperLowerHalf[i].X, sUpperLowerHalf[i].Y));
            }

            for (i = sUpperUpperHalf.Count - 1; i >= 0; i--)
            {
                marker.Add(new ScreenPoint(sUpperUpperHalf[i].X, sUpperUpperHalf[i].Y));
            }
            
            for (i = 0; i < sUpperUpperHalf.Count; i++)
            {
                marker.Add(new ScreenPoint(sUpperUpperHalf[i].X, sUpperUpperHalf[i].Y));
            }

            for (i = 0; i < sUpperLowerHalf.Count; i++)
            {
                marker.Add(new ScreenPoint(sUpperLowerHalf[i].X, sUpperLowerHalf[i].Y));
            }

            for (i = 0; i < sLowerUpperHalf.Count; i++)
            {
                marker.Add(new ScreenPoint(sLowerUpperHalf[i].X, sLowerUpperHalf[i].Y));
            }

            for (i = 0; i < sLowerLowerHalf.Count; i++)
            {
                marker.Add(new ScreenPoint(sLowerLowerHalf[i].X, sLowerLowerHalf[i].Y));
            }

            if (isNoResponse)
            {
                ScreenPoint lastPoint = marker.Last();
                ArrowMarker.AddArrowToMarker(marker, earType, lastPoint.X, lastPoint.Y);
            }

            if (addShift)
            {
                ShiftMarker.AddShift(marker, earType);
            }

            return marker.ToArray();
        }
    }
}
