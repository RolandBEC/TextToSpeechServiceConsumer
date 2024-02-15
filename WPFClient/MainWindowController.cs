using TextToSpeechServiceConsumer.WPFClient.MVVM;

namespace TextToSpeechServiceConsumer.WPFClient
{
    internal class MainWindowController
    {
        const string RequestURL = @"https://voicerss-text-to-speech.p.rapidapi.com/";

        public MainWindowVM ViewModel { get; }

        public MainWindowController()
        {
            ViewModel = new MainWindowVM()
            {
                SendToTextSpeechCommand = new RelayCommand(ExecuteSendToTextSpeechCommand, CanExecuteSendToTextSpeechCommand),
                Text = "this is a text to speech",
                Language = "en-US",
                SpeechRate = 0, /*-10 to 10*/
                SpeechAudioFormat = "mp3",
                SpeechAudioCodec = "8khz_8bit_mono",
            };
        }

        private bool CanExecuteSendToTextSpeechCommand()
        {
            return 
                !string.IsNullOrEmpty(ViewModel.Text) &&
                ViewModel.SpeechRate >= -10 &&
                ViewModel.SpeechRate <= 10;
        }

        private void ExecuteSendToTextSpeechCommand()
        {

        }
    }
}
