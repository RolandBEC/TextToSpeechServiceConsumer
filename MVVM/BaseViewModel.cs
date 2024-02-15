using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextToSpeechServiceConsumer.MVVM
{
    /// <summary>
    ///     Provide a base class for ViewModels that need implementation for INotifyPropertyChanged
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void SetProperty<T>(ref T fieldReference, T newValue, [CallerMemberName] string propertyName = null)
        {
            fieldReference = newValue;

            PropertyChangedEventHandler handler = this.PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
