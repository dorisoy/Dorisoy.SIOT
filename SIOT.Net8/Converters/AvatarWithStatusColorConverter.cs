using System;

namespace SIOT.Converters
{
    public class AvatarWithStatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string resourceName;

            var stringValue = value != null ? value.ToString() : "";

            switch (stringValue)
            {
                case nameof(AvatarStatus.Online):
                    resourceName = "Green";
                    break;

                case nameof(AvatarStatus.Busy):
                    resourceName = "Red";
                    break;

                case nameof(AvatarStatus.Away):
                    resourceName = "Orange";
                    break;

                default: // Offline
                    resourceName = "DisabledColor";
                    break;
            }

            return ResourceHelper.FindResource<Color>(resourceName);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
