/*
 *  Musin Artem
 *
 *   * * * DH-Video * * *
 * 
 *  2020 Copyright  
 */

using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using DH_Video.Libs;
using Microsoft.Win32;

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
                OnPropertyChanged(nameof(CurrentVideoName));
            }
        }
        private string _currentVideoName = "DH Video";


        public MediaTimeline TimeLine { get; set; } = new MediaTimeline();
        public Storyboard SelectionVideoStoryboard { get; set; } = new Storyboard();
        
        public MediaElement VideoPresenter { get; set; }
        
        #region Commands

        public ICommand AddVideo { get; set; }

        #endregion

        #region Constructor

        public MainWindowViewModel(ref MediaElement videoPresenter)
        {
            VideoPresenter = videoPresenter;
            
            string selectionPath;
            
            
            AddVideo = new RelayCommand(() =>
            {
                try
                {
                    FileDialog selectVideoDialogWindow =
                        new OpenFileDialog()
                        {
                            Multiselect = false,
                            Title = "Choose video...",
                            Filter = "MP4 File|*.mp4|All File|*.*"
                        };
                    // Finish executing this command
                    // ReSharper disable once PossibleInvalidOperationException
                    if (!(bool) selectVideoDialogWindow.ShowDialog()) return;
                    selectionPath = selectVideoDialogWindow.FileName;

                    TimeLine.Source = new Uri(selectionPath);

                    // Init children for control video  
                    SelectionVideoStoryboard.Children.Add(TimeLine);
                    CurrentVideoName = selectionPath;
                    
                    // Start video in the current MainWindow video presenter
                    SelectionVideoStoryboard.Begin(VideoPresenter, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        #endregion
        

    }
}