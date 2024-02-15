using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextToSpeechServiceConsumer.WPFClient.MVVM
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void SetProperty<T>(ref T fieldReference, T newValue, [CallerMemberName] string propertyName = null)
        {
            fieldReference = newValue;

            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
