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

        MainDataGrid.ItemsSource = App.dataBaseContext.Bookings.Include("User").Include("Flight").ToList();
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (CurrentUser.currentUser.IdRoleNavigation.Title != "admin")
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

    private async void btnAdd_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var addPage = new AddFlightWindow();
        var parent = this.VisualRoot as Window;
        await addPage.ShowDialog(parent);

        MainDataGrid.ItemsSource = App.dataBaseContext.Flights.ToList();
    }

    private async void btnDelete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Предупреждение", "Вы точно хотите удалить?", MsBox.Avalonia.Enums.ButtonEnum.YesNo);

        var result = await box.ShowAsync();

        if (result == MsBox.Avalonia.Enums.ButtonResult.Yes)
        {
            var SelectedItem = MainDataGrid.SelectedItem as Flight;

            if (SelectedItem == null) return;

            App.dataBaseContext.Flights.Remove(SelectedItem);
            App.dataBaseContext.SaveChanges();

            MainDataGrid.Columns.Clear();

            MainDataGrid.ItemsSource = App.dataBaseContext.Flights.ToList();
        }
        else
        {
            return;
        }
    }
}