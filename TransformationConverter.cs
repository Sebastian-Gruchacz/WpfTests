namespace ConverterDistill
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class TransformationConverter : BaseConverter
    {
        public static readonly DependencyProperty TransformationTableProperty = DependencyProperty.Register(
            "TransformationTable",
            typeof(TransformationTable),
            typeof(TransformationConverter),
            new PropertyMetadata(default(TransformationTable), PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            // do nothing, just catch when it happens
        }

        public TransformationTable TransformationTable
        {
            get
            {
                return (TransformationTable)this.GetValue(TransformationTableProperty);
            }
            set
            {
                this.SetValue(TransformationTableProperty, value);
            }
        }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (this.TransformationTable == null)
            {
                return Binding.DoNothing;// throw new InvalidOperationException("Transformation table was not provided.");
            }

            return this.TransformationTable.TransformValue(value);
        }
    }
}