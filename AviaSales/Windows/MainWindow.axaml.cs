using Avalonia.Controls;

namespace AviaSales
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainContentControl.Content = new AuthPage();
        }

        private void btnAuth_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContentControl.Content = new AuthPage();
        }
        private void btnReg_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContentControl.Content = new RegisterPage();
        }
    }
}