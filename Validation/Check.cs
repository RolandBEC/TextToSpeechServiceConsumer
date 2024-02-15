using System.Diagnostics;

namespace TextToSpeechServiceConsumer.Validation
{
    public static class Check
    {
        [DebuggerStepThrough]
        public static void ArgumentNotNull<T>([ValidatedNotNull] T value, string argumentName)
        {
            if (value == null)
                throw new ArgumentNullException(argumentName);
        }
    }
}
