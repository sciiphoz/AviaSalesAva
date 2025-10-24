using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using MsBox.Avalonia;
using System;
using System.Linq;

namespace AviaSales;

public partial class AddPromoWindow : Window
{
    public AddPromoWindow()
    {
        InitializeComponent();
    }

    private void btnSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (int.TryParse(tbDiscount.Text, out int discount))
        {
            if (discount > 0 && discount < 100)
            {

                var newPromo = new Promo()
                {
                    IdPromo = App.dataBaseContext.Promos.Any() ? Convert.ToInt32(App.dataBaseContext.Promos.Max(x => x.IdPromo).ToString()) + 1 : 1,
                    Discount = discount
                };

                App.dataBaseContext.Promos.Add(newPromo);
                App.dataBaseContext.SaveChanges();
            }
            else
            {
                var box = MessageBoxManager.GetMessageBoxStandard("Error!", "Discount value is incorrect.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
                var parent = this.VisualRoot as Window;
                box.ShowWindowDialogAsync(parent);
            }
        }
        else
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Error!", "Type in int value.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
            var parent = this.VisualRoot as Window;
            box.ShowWindowDialogAsync(parent);
        }
    }
}