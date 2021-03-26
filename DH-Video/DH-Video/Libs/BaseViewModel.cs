using System.ComponentModel;
using System.Runtime.CompilerServices;
using DH_Video.Annotations;

namespace DH_Video.Libs
{
    /// <summary>
    /// Basic ViewModel of pattern MVVM
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Basic PropertyChangedEvent
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Tell view that value in the viewmodel was changed. Realization basic PropertyChange event.
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}