using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;

namespace AviaSales;

public partial class NavigationWindow : Window
{
    public NavigationWindow()
    {
        InitializeComponent();

        MainContentControl.Content = new FlightPage();

        if (CurrentUser.currentUser.IdRole == 1)
        {

        }

        UserName.Text = CurrentUser.currentUser.IdRoleNavigation?.Title;
    }

    private void btnBooking_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainContentControl.Content = new BookingPage();
    }
    private void btnUser_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainContentControl.Content = new UserPage();
    }
    private void btnPromo_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainContentControl.Content = new PromoPage();
    }
    private void btnFlight_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainContentControl.Content = new FlightPage();
    }
    private void btnProfile_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainContentControl.Content = new ProfilePage();
    }
}