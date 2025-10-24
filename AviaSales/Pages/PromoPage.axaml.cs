using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using MsBox.Avalonia;
using System.Linq;

namespace AviaSales;

public partial class PromoPage : UserControl
{
    public PromoPage()
    {
        InitializeComponent();

        MainDataGrid.ItemsSource = App.dataBaseContext.Promos.ToList();

        if (CurrentUser.currentUser.IdRole == 2)
        {
            btnAdd.IsVisible = false;
            btnDelete.IsVisible = false;
        }
    }

    private async void MainDataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (CurrentUser.currentUser.IdRole != 3)
        {
            return;
        }
        else
        {
            var selectedPromo = MainDataGrid.SelectedItem as Promo;

            if (selectedPromo == null) return;

            ContextPromo.promo = selectedPromo;

            var editPage = new EditPromoWindow(new Promo());
            var parent = this.VisualRoot as Window;
            await editPage.ShowDialog(parent);

            MainDataGrid.ItemsSource = App.dataBaseContext.Promos.ToList();
        }
    }

    private async void btnAdd_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var addPage = new AddPromoWindow();
        var parent = this.VisualRoot as Window;
        await addPage.ShowDialog(parent);

        MainDataGrid.ItemsSource = App.dataBaseContext.Users.ToList();
    }

    private async void btnDelete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Warning.", "Are you sure you want to delete this promo?", MsBox.Avalonia.Enums.ButtonEnum.YesNo, MsBox.Avalonia.Enums.Icon.Warning);

        var result = await box.ShowAsync();

        if (result == MsBox.Avalonia.Enums.ButtonResult.Yes)
        {
            var SelectedItem = MainDataGrid.SelectedItem as User;

            if (SelectedItem == null) return;

            App.dataBaseContext.Users.Remove(SelectedItem);
            App.dataBaseContext.SaveChanges();

            MainDataGrid.ItemsSource = App.dataBaseContext.Users.ToList();
        }
        else
        {
            return;
        }
    }
}