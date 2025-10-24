using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using MsBox.Avalonia;

namespace AviaSales;

public partial class EditPromoWindow : Window
{
    private Promo promo;
    private Promo currentPromo;
    public EditPromoWindow()
    {
        InitializeComponent();

        promo = ContextPromo.promo;
    }

    public EditPromoWindow(Promo promo)
    {
        InitializeComponent();

        promo = ContextPromo.promo;
        currentPromo = promo;

        tbDiscount.Text = promo.Discount.ToString();
    }

    private void btnSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (int.TryParse(tbDiscount.Text, out int discount))
        {
            currentPromo.Discount = discount;

            App.dataBaseContext.Update(currentPromo);
            App.dataBaseContext.SaveChanges();
        }
        else
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Error!", "Type in int value.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
            var parent = this.VisualRoot as Window;
            box.ShowWindowDialogAsync(parent);
        }
    }
}