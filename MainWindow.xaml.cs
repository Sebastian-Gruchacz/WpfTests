namespace ConverterDistill
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty TransformationTableProperty = DependencyProperty.Register(
            "TransformationTable",
            typeof(TransformationTable),
            typeof(MainWindow),
            new PropertyMetadata(default(TransformationTable)));

        public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register(
            "DisplayText",
            typeof(string),
            typeof(MainWindow),
            new PropertyMetadata(default(string)));

        public MainWindow()
        {
            this.InitializeComponent();

            this.TransformationTable = new TransformationTable(); // created very early, so shall always exists...
            this.DisplayText = "Some text to be displayed - constructor";
            this.DataContext = this;
        }

        public TransformationTable TransformationTable
        {
            get
            {
                return (TransformationTable)GetValue(TransformationTableProperty);
            }
            set
            {
                SetValue(TransformationTableProperty, value);
            }
        }

        public string DisplayText
        {
            get
            {
                return (string)GetValue(DisplayTextProperty);
            }
            set
            {
                SetValue(DisplayTextProperty, value);
            }
        }
    }
}
