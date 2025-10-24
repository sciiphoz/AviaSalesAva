using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using System;
using System.Linq;

namespace AviaSales;

public partial class BookingPage : UserControl
{
    public BookingPage()
    {
        InitializeComponent();

        MainDataGrid.ItemsSource = App.dataBaseContext.Bookings.Include("IdFlightNavigation").Include("IdUserNavigation").ToList();

        if (CurrentUser.currentUser.IdRole == 2)
        {
            btnDelete.IsVisible = false;
        }
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (CurrentUser.currentUser.IdRole != 3)
        {
            return;
        }
        else
        {
            var selectedFlight = MainDataGrid.SelectedItem as Flight;

            if (selectedFlight == null) return;

            ContextFlights.flight = selectedFlight;

            var editPage = new EditFlightWindow(new Flight());
            var parent = this.VisualRoot as Window;
            await editPage.ShowDialog(parent);

            MainDataGrid.ItemsSource = App.dataBaseContext.Flights.ToList();
        }
    }

    private async void btnDelete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Предупреждение", "Вы точно хотите удалить?", MsBox.Avalonia.Enums.ButtonEnum.YesNo);

        var result = await box.ShowAsync();

        if (result == MsBox.Avalonia.Enums.ButtonResult.Yes)
        {
            var SelectedItem = MainDataGrid.SelectedItem as Booking;

            if (SelectedItem == null) return;

            App.dataBaseContext.Bookings.Remove(SelectedItem);
            App.dataBaseContext.SaveChanges();

            MainDataGrid.ItemsSource = App.dataBaseContext.Bookings.Include("IdFlightNavigation").Include("IdUserNavigation").ToList();
        }
        else
        {
            return;
        }
    }
}