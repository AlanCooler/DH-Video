using DH_Video.ViewModels;

namespace DH_Video
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel(ref VideoPresenter);
        }
    }
}