using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
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
        if (!(userName.Text == string.Empty || userEmail.Text == string.Empty))
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
                return;
            }
        }
        else
        {
            return;
        }
    }
}