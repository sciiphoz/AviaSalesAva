using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using MsBox.Avalonia;
using System;
using System.Linq;

namespace AviaSales;

public partial class FlightPage : UserControl
{
    public FlightPage()
    {
        InitializeComponent();

        //MainDataGrid.ItemsSource = App.dataBaseContext.Flights.ToList();

        MainListBox.ItemsSource = App.dataBaseContext.Flights.ToList();

        if (CurrentUser.currentUser.IdRoleNavigation?.Title == "passenger" || CurrentUser.currentUser.IdRoleNavigation?.Title == "manager")
        {
            btnAdd.IsVisible = false;
            btnDelete.IsVisible = false;
        }
    }

    private async void DataGrid_DoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {


        //if (CurrentUser.currentUser.IdRoleNavigation?.Title != "admin")
        //{
        //    return;
        //}
        //else
        //{
        //    var selectedFlight = MainDataGrid.SelectedItem as Flight;

        //    if (selectedFlight == null) return;

        //    ContextFlights.flight = selectedFlight;

        //    var editPage = new EditFlightWindow(new Flight());
        //    var parent = this.VisualRoot as Window;
        //    await editPage.ShowDialog(parent);

        //    MainDataGrid.ItemsSource = App.dataBaseContext.Flights.ToList();
        //}
    }

    private async void btnAdd_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //var addPage = new AddFlightWindow();
        //var parent = this.VisualRoot as Window;
        //await addPage.ShowDialog(parent);

        //MainDataGrid.ItemsSource = App.dataBaseContext.Flights.ToList();
    }

    private async void btnAddToBooking_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //var SelectedItem = MainDataGrid.SelectedItem as Flight;

        //if (SelectedItem == null) return;

        //if (App.dataBaseContext.Bookings.FirstOrDefault(x => x.IdFlight == SelectedItem.IdFlight && x.IdUser == CurrentUser.currentUser.IdUser) == null)
        //{
        //    App.dataBaseContext.Bookings.Add(new Booking
        //    {
        //        IdBooking = App.dataBaseContext.Bookings.Any() == false ? 1 : Convert.ToInt32(App.dataBaseContext.Bookings.Max(x => x.IdBooking).ToString()) + 1,
        //        IdFlight = SelectedItem.IdFlight,
        //        IdUser = CurrentUser.currentUser.IdUser,
        //    });

        //    App.dataBaseContext.SaveChanges();
        //}
        //else
        //{
        //    return;
        //}
    }

    private async void btnDelete_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //var box = MessageBoxManager.GetMessageBoxStandard("Предупреждение", "Вы точно хотите удалить?", MsBox.Avalonia.Enums.ButtonEnum.YesNo);

        //var result = await box.ShowAsync();

        //if (result == MsBox.Avalonia.Enums.ButtonResult.Yes)
        //{
        //    var SelectedItem = MainDataGrid.SelectedItem as Flight;

        //    if (SelectedItem == null) return;

        //    App.dataBaseContext.Flights.Remove(SelectedItem);
        //    App.dataBaseContext.SaveChanges();

        //    MainDataGrid.Columns.Clear();

        //    MainDataGrid.ItemsSource = App.dataBaseContext.Flights.ToList();
        //}
        //else
        //{
        //    return;
        //}
    }
}

		//<DataGrid Name = "MainDataGrid" IsReadOnly="True"
		//		HorizontalAlignment="Center" VerticalAlignment="Center"
		//		DoubleTapped="DataGrid_DoubleTapped"
		//		Grid.Row="0"
		//		GridLinesVisibility="All">
		//	<DataGrid.Columns>
		//		<DataGridTextColumn Header = "Airline" Binding="{Binding Airline}"></DataGridTextColumn>
		//		<DataGridTextColumn Header = "Aircraft" Binding="{Binding Aircraft}"></DataGridTextColumn>
		//		<DataGridTextColumn Header = "Departure city" Binding="{Binding DepartureCity}"></DataGridTextColumn>
		//		<DataGridTextColumn Header = "Arrival city" Binding="{Binding ArrivalCity}"></DataGridTextColumn>
		//		<DataGridTextColumn Header = "Departure time" Binding="{Binding DepartureTime}"></DataGridTextColumn>
		//		<DataGridTextColumn Header = "Arrival time" Binding="{Binding ArrivalTime}"></DataGridTextColumn>
		//		<DataGridTextColumn Header = "Flight time" Binding="{Binding FlightTime}"></DataGridTextColumn>
		//		<DataGridTextColumn Header = "Price" Binding="{Binding Price}"></DataGridTextColumn>
		//		<DataGridTextColumn Header = "Class" Binding="{Binding Class}"></DataGridTextColumn>
		//		<DataGridTextColumn Header = "Seat number" Binding="{Binding SeatNumber}"></DataGridTextColumn>
		//		<DataGridTextColumn Header = "Status" Binding="{Binding Status}"></DataGridTextColumn>
		//	</DataGrid.Columns>
		//</DataGrid>