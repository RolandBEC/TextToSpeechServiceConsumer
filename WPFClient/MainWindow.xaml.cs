using System.Windows;
using TextToSpeechServiceConsumer.WPFClient;

namespace TextToSpeechServiceConsumer
{
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