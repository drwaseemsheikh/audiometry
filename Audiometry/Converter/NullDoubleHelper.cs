namespace Audiometry.Converter
{
    public static class NullDoubleHelper
    {
        public static double? ToNullableDouble(string dstr)
        {
            double d;
            if (double.TryParse(dstr, out d))
            {
                return d;
            }

            return null;
        }
    }
}
