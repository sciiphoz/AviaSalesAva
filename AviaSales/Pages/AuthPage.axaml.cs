using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using MsBox.Avalonia;
using System.Linq;

namespace AviaSales;

public partial class AuthPage : UserControl
{
    public AuthPage()
    {
        InitializeComponent();
    }

    private void btnSubmit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (userEmail.Text == string.Empty || userPassword.Text == string.Empty)
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Error!", "All fields must be filled.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
            var parent = this.VisualRoot as Window;
            box.ShowWindowDialogAsync(parent);
        }
        else
        {
            if (App.dataBaseContext.Users.FirstOrDefault(x => x.Email == userEmail.Text && x.Password == userPassword.Text) != null)
            {
                CurrentUser.currentUser = App.dataBaseContext.Users.FirstOrDefault(x => x.Email == userEmail.Text && x.Password == userPassword.Text);
                var parent = this.VisualRoot as Window;
                var nav = new NavigationWindow();
                nav.Show();
                parent.Close();
            }
            else
            {
                var box = MessageBoxManager.GetMessageBoxStandard("Error!", "Authorization error.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
                var parent = this.VisualRoot as Window;
                box.ShowWindowDialogAsync(parent);
            }
        }
    }
}