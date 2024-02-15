using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Text = "this is an text to speech",
                Language = "en-US",
                SpeechRate = 0, /*-10 to 10*/
                SpeechAudioFormat = "mp3",
                SpeechAudioCodec = "8khz_8bit_mono",
            };
        }
    }
}
