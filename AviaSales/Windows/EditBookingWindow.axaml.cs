using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using System.Linq;

namespace AviaSales;

public partial class EditBookingWindow : Window
{
    private Booking _booking;
    private Booking _currentBooking;
    public EditBookingWindow()
    {
        InitializeComponent();

        _booking = ContextBooking.booking;
    }

    public EditBookingWindow(Booking booking)
    {
        InitializeComponent();

        booking = ContextBooking.booking;
        _currentBooking = booking;

        cbUser.ItemsSource = App.dataBaseContext.Users.ToList();
        cbFlight.ItemsSource = App.dataBaseContext.Flights.ToList();

        cbUser.SelectedItem = booking.IdUserNavigation;
        cbFlight.SelectedItem = booking.IdFlightNavigation;
    }

    private void btnSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _currentBooking.IdUser = cbUser.SelectedIndex + 1;
        _currentBooking.IdFlight = cbFlight.SelectedIndex + 1;

        App.dataBaseContext.Update(_currentBooking);
        App.dataBaseContext.SaveChanges();

        this.Close();
    }
}