using Microsoft.UI.Xaml;
using FontAwesome5.WinUI.Example.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FontAwesome5.WinUI.Example
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            if (this.Content is FrameworkElement element)
                element.DataContext = new MainViewModel();
        }
    }
}
