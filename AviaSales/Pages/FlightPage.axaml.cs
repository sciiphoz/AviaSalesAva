using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using MsBox.Avalonia;
using System;
using System.Linq;

namespace AviaSales;

public partial class FlightPage : UserControl
{
    public FlightPage()
    {
        InitializeComponent();

        MainListBox.ItemsSource = App.dataBaseContext.Flights.ToList();

        if (CurrentUser.currentUser.IdRole == 1 || CurrentUser.currentUser.IdRole == 2)
        {
            btnAdd.IsVisible = false;
            btnDelete.IsVisible = false;
        }
    }

    private async void btnAdd_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var addPage = new AddFlightWindow();
        var parent = this.VisualRoot as Window;
        await addPage.ShowDialog(parent);

        MainListBox.ItemsSource = App.dataBaseContext.Flights.ToList();
    }

    private async void btnAddToBooking_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var SelectedItem = MainListBox.SelectedItem as Flight;

        if (SelectedItem == null) return;

        if (App.dataBaseContext.Bookings.FirstOrDefault(x => x.IdFlight == SelectedItem.IdFlight && x.IdUser == CurrentUser.currentUser.IdUser) == null)
        {
            App.dataBaseContext.Bookings.Add(new Booking
            {
                IdBooking = App.dataBaseContext.Bookings.Any() ? Convert.ToInt32(App.dataBaseContext.Bookings.Max(x => x.IdBooking).ToString()) + 1 : 1,
                IdFlight = SelectedItem.IdFlight,
                IdUser = CurrentUser.currentUser.IdUser,
            }); 

            App.dataBaseContext.SaveChanges();
        }
        else
        {
            return;
        }
    }

    private async void btnDelete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Предупреждение", "Вы точно хотите удалить?", MsBox.Avalonia.Enums.ButtonEnum.YesNo);

        var result = await box.ShowAsync();

        if (result == MsBox.Avalonia.Enums.ButtonResult.Yes)
        {
            var SelectedItem = MainListBox.SelectedItem as Flight;

            if (SelectedItem == null) return;

            App.dataBaseContext.Flights.Remove(SelectedItem);
            App.dataBaseContext.SaveChanges();

            MainListBox.ItemsSource = App.dataBaseContext.Flights.ToList();
        }
        else
        {
            return;
        }
    }

    private async void MainListBox_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (CurrentUser.currentUser.IdRole != 3)
        {
            return;
        }
        else
        {
            var selectedFlight = MainListBox.SelectedItem as Flight;

            if (selectedFlight == null) return;

            ContextFlights.flight = selectedFlight;

            var editPage = new EditFlightWindow(new Flight());
            var parent = this.VisualRoot as Window;
            await editPage.ShowDialog(parent);

            MainListBox.ItemsSource = App.dataBaseContext.Flights.ToList();
        }
    }
}