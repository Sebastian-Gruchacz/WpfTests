namespace ConverterDistill
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public abstract class BaseConverter : DependencyObject, IValueConverter
    {
        public static readonly DependencyProperty FormatterProperty = 
            DependencyProperty.Register("Formatter", typeof(string), typeof(BaseConverter), new PropertyMetadata(default(string)));

        public string Formatter
        {
            get
            {
                return (string)GetValue(FormatterProperty);
            }
            set
            {
                SetValue(FormatterProperty, value);
            }
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value; // Just for sake
        }
    }
}
