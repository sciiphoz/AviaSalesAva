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

        RefreshData();

        userName.Text = CurrentUser.currentUser.Name;
        userEmail.Text = CurrentUser.currentUser.Email;
    }

    private async void btnDelete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Warning.", "Are you sure you want to cancel your booking?", MsBox.Avalonia.Enums.ButtonEnum.YesNo, MsBox.Avalonia.Enums.Icon.Warning);

        var result = await box.ShowAsync();

        if (result == MsBox.Avalonia.Enums.ButtonResult.Yes)
        {
            var SelectedItem = MainListBox.SelectedItem as dynamic;

            if (SelectedItem == null) return;

            App.dataBaseContext.Bookings.Remove(SelectedItem.Booking);
            App.dataBaseContext.SaveChanges();

            RefreshData();
        }
        else
        {
            return;
        }
    }

    private void RefreshData()
    {
        var bookings = App.dataBaseContext.Bookings.Include("IdFlightNavigation").Include("IdFlightNavigation.IdPromoNavigation").Where(x => x.IdUser == CurrentUser.currentUser.IdUser).ToList();

        var bookingsWithDiscount = bookings.Select(x => new
        {
            Booking = x,
            DiscountedPrice = CalculateDiscountedPrice(x.IdFlightNavigation)
        }).ToList();

        MainListBox.ItemsSource = bookingsWithDiscount;
    }

    private int CalculateDiscountedPrice(Flight flight)
    {
        if (flight?.Price == null)
            return 0;

        var originalPrice = flight.Price.Value;

        if (flight.IdPromoNavigation?.Discount != null)
        {
            var discount = flight.IdPromoNavigation.Discount.Value;
            return originalPrice - (originalPrice * discount / 100);
        }

        return originalPrice;
    }
}