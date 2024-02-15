using System.Diagnostics;
using System.Windows.Input;
using TextToSpeechServiceConsumer.Validation;

namespace TextToSpeechServiceConsumer.MVVM
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;
        private readonly List<EventHandler> canExecuteDelegates;
        private EventHandler _canExecuteChanged;

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            Check.ArgumentNotNull(execute, nameof(execute));

            _execute = execute;
            _canExecute = canExecute;
            canExecuteDelegates = new List<EventHandler>();
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                _canExecuteChanged += value;
                CommandManager.RequerySuggested += value;

                canExecuteDelegates.Add(value);
            }
            remove
            {
                _canExecuteChanged -= value;
                CommandManager.RequerySuggested -= value;

                canExecuteDelegates.Remove(value);
            }
        }

        public void Execute(object parameter)
        {
            try
            {
                _execute((T)parameter);
            }
            catch (Exception ex)
            {
            }
        }

        public void RaiseCanExecuteChanged()
        {
            if (_canExecute != null)
                OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            _canExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void UnsubscribeCanExecute()
        {
            foreach (EventHandler canExecuteDelegate in canExecuteDelegates)
            {
                _canExecuteChanged -= canExecuteDelegate;
                CommandManager.RequerySuggested -= canExecuteDelegate;
            }

            canExecuteDelegates.Clear();
        }
    }
}
