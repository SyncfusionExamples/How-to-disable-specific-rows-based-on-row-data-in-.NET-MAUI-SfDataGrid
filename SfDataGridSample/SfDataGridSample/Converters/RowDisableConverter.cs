using System.Globalization;

namespace SfDataGridSample.Converters
{
    public class RowDisableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is OrderInfo orderInfo)
            {
                // Return a lighter opacity/grayed-out appearance for external rows
                if (orderInfo.IsExternal)
                {
                    return 0.5; // 50% opacity for disabled rows
                }
            }
            return 1.0; // Full opacity for enabled rows
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
