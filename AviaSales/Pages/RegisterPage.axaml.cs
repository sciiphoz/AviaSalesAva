using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using MsBox.Avalonia;
using System;
using System.Linq;

namespace AviaSales;

public partial class RegisterPage : UserControl
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private void btnSubmit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!(userName.Text == string.Empty || userEmail.Text == string.Empty || userPassword.Text == string.Empty || confirmPassword.Text == string.Empty))
        {
            if (userPassword.Text.Length >= 8) 
            {
                if (userPassword.Text == confirmPassword.Text)
                {

                    var newUser = new User()
                    {
                        IdUser = App.dataBaseContext.Users.Any() == false ? 1 : Convert.ToInt32(App.dataBaseContext.Users.Max(x => x.IdUser).ToString()) + 1,
                        Name = userName.Text,
                        Email = userEmail.Text,
                        Password = userPassword.Text,
                        IdRole = 1
                    };

                    CurrentUser.currentUser = newUser;

                    App.dataBaseContext.Users.Add(newUser);
                    App.dataBaseContext.SaveChanges();

                    var parent = this.VisualRoot as Window;
                    var nav = new NavigationWindow();
                    nav.Show();
                    parent.Close();
                }
                else
                {
                    var box = MessageBoxManager.GetMessageBoxStandard("Error!", "Password not confirmed.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
                    var parent = this.VisualRoot as Window;
                    box.ShowWindowDialogAsync(parent);
                }
            }
            else
            {
                var box = MessageBoxManager.GetMessageBoxStandard("Error!", "Password should be at least 8 characters.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
                var parent = this.VisualRoot as Window;
                box.ShowWindowDialogAsync(parent);
            }
        }
        else
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Error!", "All fields must be filled.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
            var parent = this.VisualRoot as Window;
            box.ShowWindowDialogAsync(parent);
        }

    }
}