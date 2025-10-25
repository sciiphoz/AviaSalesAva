using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using MsBox.Avalonia;
using System;

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
        try
        {
            if (int.TryParse(tbDiscount.Text, out int discount))
            {
                if (discount > 0 && discount < 100)
                {
                    currentPromo.Discount = discount;

                    App.dataBaseContext.Update(currentPromo);
                    App.dataBaseContext.SaveChanges();

                    this.Close();
                }
                else
                {
                    throw new Exception("Discount value is incorrect.");
                }
            }
            else
            {
                throw new Exception("Type in int value.");
            }
        }
        catch (Exception ex)
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Error!", ex.Message, MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
            var parent = this.VisualRoot as Window;
            box.ShowWindowDialogAsync(parent);
        }

    }
}