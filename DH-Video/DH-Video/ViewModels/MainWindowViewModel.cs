/*
 *  Musin Artem
 *
 *   * * * DH-Video * * *
 * 
 *  2020 Copyright  
 */

using DH_Video.Libs;

namespace DH_Video.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// The name of video which is playing right now
        /// </summary>
        public string CurrentVideoName
        {
            get => _currentVideoName;
            set
            {
                _currentVideoName = value;
                // Change this value
                OnPropertyChanged(CurrentVideoName);
            }
        }
        private string _currentVideoName = "DH Video";

        
    }
}