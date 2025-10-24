using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using System.Linq;

namespace AviaSales;

public partial class ProfilePage : UserControl
{
    public ProfilePage()
    {
        InitializeComponent();

        MainDataGrid.ItemsSource = App.dataBaseContext.Bookings.Include("IdFlightNavigation").Where(x => x.IdUser == CurrentUser.currentUser.IdUser).ToList();

        userName.Text = CurrentUser.currentUser.Name;
        userEmail.Text = CurrentUser.currentUser.Email;
    }

    private async void btnDelete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Warning.", "Are you sure you want to cancel your booking?", MsBox.Avalonia.Enums.ButtonEnum.YesNo, MsBox.Avalonia.Enums.Icon.Warning);

        var result = await box.ShowAsync();

        if (result == MsBox.Avalonia.Enums.ButtonResult.Yes)
        {
            var SelectedItem = MainDataGrid.SelectedItem as Booking;

            if (SelectedItem == null) return;

            App.dataBaseContext.Bookings.Remove(SelectedItem);
            App.dataBaseContext.SaveChanges();

            MainDataGrid.ItemsSource = App.dataBaseContext.Bookings.Include("IdFlightNavigation").Where(x => x.IdUser == CurrentUser.currentUser.IdUser).ToList();
        }
        else
        {
            return;
        }
    }
}