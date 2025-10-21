using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
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
            return;
        }
    }
}