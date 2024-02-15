using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextToSpeechServiceConsumer
{
    internal class MainWindowController
    {
        const string RequestURL = @"https://voicerss-text-to-speech.p.rapidapi.com/";

        public MainWindowVM ViewModel { get; } = new MainWindowVM();


    }
}
