using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using MsBox.Avalonia;
using System.Linq;

namespace AviaSales;

public partial class UserPage : UserControl
{
    public UserPage()
    {
        InitializeComponent();

        MainDataGrid.ItemsSource = App.dataBaseContext.Users.ToList();
    }

    private async void btnDelete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Предупреждение", "Вы точно хотите удалить?", MsBox.Avalonia.Enums.ButtonEnum.YesNo);

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