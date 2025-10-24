using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using ExCSS;
using MsBox.Avalonia;
using System;
using System.Xml.Linq;

namespace AviaSales;

public partial class EditFlightWindow : Window
{
    private Flight flight;
    private Flight currentFlight; 
    public EditFlightWindow()
    {
        InitializeComponent();

        flight = ContextFlights.flight;
    }

    public EditFlightWindow(Flight flight)
    {
        InitializeComponent();

        flight = ContextFlights.flight;
        currentFlight = flight;

        tbAirline.Text = flight.Airline;
        tbAircraft.Text = flight.Aircraft;
        tbDepartureCity.Text = flight.DepartureCity;
        tbArrivalCity.Text = flight.ArrivalCity;
        tbDepartureTime.Text = flight.DepartureTime.ToString();
        tbArrivalTime.Text = flight.ArrivalTime.ToString();
        tbPrice.Text = flight.Price.ToString();
        tbClass.Text = flight.Class;
        tbSeatNumber.Text = flight.SeatNumber.ToString();
        tbStatus.Text = flight.Status;
        tbPromo.Text = flight.IdPromo.ToString();
    }

    private void btnSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (tbAirline.Text == string.Empty || tbAircraft.Text == string.Empty ||
        tbDepartureCity.Text == string.Empty ||
        tbArrivalCity.Text == string.Empty ||
        tbDepartureTime.Text == null ||
        tbArrivalTime.Text == null ||
        tbPrice.Text == string.Empty ||
        tbSeatNumber.Text == string.Empty)
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Error!", "All fields must be filled.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
            var parent = this.VisualRoot as Window;
            box.ShowWindowDialogAsync(parent);
        }
        else
        {
            if (tbDepartureCity.Text == tbArrivalCity.Text)
            {
                var box = MessageBoxManager.GetMessageBoxStandard("Error!", "Departure city and arrival city can't be the same.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
                var parent = this.VisualRoot as Window;
                box.ShowWindowDialogAsync(parent);
            }
            else
            {
                if (!DateOnly.TryParse(tbDepartureTime.Text, out DateOnly departureTime) || !DateOnly.TryParse(tbArrivalTime.Text, out DateOnly arrivalTime))
                {
                    var box = MessageBoxManager.GetMessageBoxStandard("Error!", "Dates have dd-mm-yyyy format.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
                    var parent = this.VisualRoot as Window;
                    box.ShowWindowDialogAsync(parent);
                }
                else
                {
                    if (departureTime == arrivalTime)
                    {
                        var box = MessageBoxManager.GetMessageBoxStandard("Error!", "Dates can't be the same.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
                        var parent = this.VisualRoot as Window;
                        box.ShowWindowDialogAsync(parent);
                    }
                    else
                    {
                        if (Convert.ToInt32(tbPrice.Text) <= 0 || Convert.ToInt32(tbPrice.Text) >= 500000)
                        {
                            var box = MessageBoxManager.GetMessageBoxStandard("Error!", "Ticket price must be relevant.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
                            var parent = this.VisualRoot as Window;
                            box.ShowWindowDialogAsync(parent);
                        }
                        else
                        {
                            if (Convert.ToInt32(tbSeatNumber.Text) <= 0 || Convert.ToInt32(tbSeatNumber.Text) >= 1000)
                            {
                                var box = MessageBoxManager.GetMessageBoxStandard("Error!", "Seat number must be relevant.", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
                                var parent = this.VisualRoot as Window;
                                box.ShowWindowDialogAsync(parent);
                            }
                            else
                            {
                                currentFlight.Airline = tbAirline.Text;
                                currentFlight.Aircraft = tbAircraft.Text;
                                currentFlight.DepartureCity = tbDepartureCity.Text;
                                currentFlight.ArrivalCity = tbArrivalCity.Text;

                                currentFlight.DepartureTime = departureTime;
                                currentFlight.ArrivalTime = arrivalTime;

                                currentFlight.Price = Convert.ToInt32(tbPrice.Text);
                                currentFlight.Class = tbClass.Text;
                                currentFlight.SeatNumber = Convert.ToInt32(tbSeatNumber.Text);
                                currentFlight.Status = tbStatus.Text;
                                currentFlight.IdPromo = tbPromo.Text == string.Empty ? null : Convert.ToInt32(tbPromo.Text);

                                App.dataBaseContext.Flights.Update(currentFlight);
                                App.dataBaseContext.SaveChanges();

                                Close();
                            }
                        }
                    }
                }
            }
        }
    }
}