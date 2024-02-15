using TextToSpeechServiceConsumer.MVVM;

namespace TextToSpeechServiceConsumer
{
    public class MainWindowVM : BaseViewModel
    {
        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private string _language;
        public string Language
        {
            get => _language;
            set => SetProperty(ref _language, value);
        }

        private int _speechRate;
        public int SpeechRate
        {
            get => _speechRate;
            set => SetProperty(ref _speechRate, value);
        }

        private string _speechAudioCodec;
        public string SpeechAudioCodec
        {
            get => _speechAudioCodec;
            set => SetProperty(ref _speechAudioCodec, value);
        }

        private string _speechAudioFormat;
        public string SpeechAudioFormat
        {
            get => _speechAudioFormat;
            set => SetProperty(ref _speechAudioFormat, value);
        }

    }
}
