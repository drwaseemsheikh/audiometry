using System.Collections.Generic;
using System.ComponentModel;
using Audiometry.ViewModel.PureToneVM.PureToneAMData;
using OxyPlot;

namespace Audiometry.ViewModel.PureToneVM.Audiogram.Marker
{
    public static class ShiftMarker
    {
        private static AGPoint GetShift(EarType earType)
        {
            const double shiftX = 0.2;
            const double shiftY = 0.1;
            AGPoint shift = new AGPoint();
            if (earType == EarType.RightEar)
            {
                shift.X = -shiftX;
                shift.Y = shiftY;
            }
            else if (earType == EarType.LeftEar)
            {
                shift.X = shiftX;
                shift.Y = -shiftY;
            }
            else
            {
                throw new InvalidEnumArgumentException();
            }
            return shift;
        }

        public static void AddShift(List<ScreenPoint> marker, EarType earType)
        {
            AGPoint shift = GetShift(earType);

            for (int i = 0; i < marker.Count; i++)
            {
                marker[i] = new ScreenPoint(marker[i].X + shift.X, marker[i].Y + shift.Y);
            }
        }
    }
}
