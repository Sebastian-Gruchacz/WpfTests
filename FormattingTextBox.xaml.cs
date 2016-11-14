namespace ConverterDistill
{
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Interaction logic for FormattingTextBox.xaml
    /// </summary>
    public partial class FormattingTextBox
    {
        #region Static Declarations

        public static readonly DependencyProperty ConverterProperty = DependencyProperty.Register(
           "Converter",
           typeof(BaseConverter),
           typeof(FormattingTextBox),
           new PropertyMetadata(default(BaseConverter), ConverterPropertyChangedCallback));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
           "Value",
           typeof(object),
           typeof(FormattingTextBox),
           new PropertyMetadata(null, ValuePropertyChangedCallback));

        private static void ValuePropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            FormattingTextBox @this = dependencyObject as FormattingTextBox;
            @this.Rebind();
        }

        private static void ConverterPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            FormattingTextBox @this = dependencyObject as FormattingTextBox;
            @this.Rebind();
        }

        #endregion Static Declarations

        public FormattingTextBox()
        {
            InitializeComponent();
        }

        public BaseConverter Converter
        {
            get
            {
                return (BaseConverter)GetValue(ConverterProperty);
            }
            set
            {
                SetValue(ConverterProperty, value);
            }
        }

        public object Value
        {
            get
            {
                return (object)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        private void Rebind()
        {
            this.Box.SetBinding(
                System.Windows.Controls.TextBox.TextProperty,
                new Binding()
                {
                    Converter = this.Converter,
                    ConverterCulture = CultureInfo.InvariantCulture, // simplified in example
                    ConverterParameter = null, // simplified in example, normally contains custom control state used by converters hierarchy
                    Source = this,
                    Path = new PropertyPath(ValueProperty),
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.LostFocus
                });
        }
    }
}
