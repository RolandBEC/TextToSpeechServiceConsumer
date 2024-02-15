using System.Windows;

namespace TextToSpeechServiceConsumer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowController controller;

        public MainWindow()
        {
            InitializeComponent();

            controller = new MainWindowController();
            this.DataContext = controller.ViewModel;
        }
    }
}