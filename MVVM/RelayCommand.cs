using System.Diagnostics;
using System.Windows.Input;
using TextToSpeechServiceConsumer.Validation;

namespace TextToSpeechServiceConsumer.MVVM
{

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        private readonly List<EventHandler> canExecuteDelegates;
        private EventHandler _canExecuteChanged;

        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            Check.ArgumentNotNull(execute, nameof(execute));

            _execute = execute;
            _canExecute = canExecute;
            canExecuteDelegates = new List<EventHandler>();
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
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
                _execute();
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
