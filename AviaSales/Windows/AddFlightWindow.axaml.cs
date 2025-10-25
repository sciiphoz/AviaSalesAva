using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using MsBox.Avalonia;
using System;
using System.Linq;

namespace AviaSales;

public partial class AddFlightWindow : Window
{
    public AddFlightWindow()
    {
        InitializeComponent();
    }

    private void btnSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var newFlight = new Flight();

        try
        {
            if (tbAirline.Text == string.Empty || tbAircraft.Text == string.Empty ||
                tbDepartureCity.Text == string.Empty ||
                tbArrivalCity.Text == string.Empty ||
                tbDepartureTime.Text == null ||
                tbArrivalTime.Text == null ||
                tbPrice.Text == string.Empty ||
                tbSeatNumber.Text == string.Empty)
            {
                throw new Exception("All fields must be filled.");
            }
            else
            {
                if (tbDepartureCity.Text == tbArrivalCity.Text)
                {
                    throw new Exception("Departure city and arrival city can't be the same.");
                }
                else
                {
                    if (!DateOnly.TryParse(tbDepartureTime.Text, out DateOnly departureTime) || !DateOnly.TryParse(tbArrivalTime.Text, out DateOnly arrivalTime))
                    {
                        throw new Exception("Dates have dd-mm-yyyy format.");
                    }
                    else
                    {
                        if (departureTime == arrivalTime)
                        {
                            throw new Exception("Dates can't be the same.");
                        }
                        else
                        {
                            if (Convert.ToInt32(tbPrice.Text) <= 0 || Convert.ToInt32(tbPrice.Text) >= 500000)
                            {
                                throw new Exception("Ticket price must be relevant.");
                            }
                            else
                            {
                                if (Convert.ToInt32(tbSeatNumber.Text) <= 0 || Convert.ToInt32(tbSeatNumber.Text) >= 1000)
                                {
                                    throw new Exception("Seat number must be relevant.");
                                }
                                else
                                {
                                    newFlight.IdFlight = Convert.ToInt32(App.dataBaseContext.Flights.Max(x => x.IdFlight).ToString()) + 1;
                                    newFlight.Airline = tbAirline.Text;
                                    newFlight.Aircraft = tbAircraft.Text;
                                    newFlight.DepartureCity = tbDepartureCity.Text;
                                    newFlight.ArrivalCity = tbArrivalCity.Text;

                                    newFlight.DepartureTime = departureTime;
                                    newFlight.ArrivalTime = arrivalTime;

                                    newFlight.Price = Convert.ToInt32(tbPrice.Text);
                                    newFlight.Class = tbClass.Text;
                                    newFlight.SeatNumber = Convert.ToInt32(tbSeatNumber.Text);
                                    newFlight.Status = tbStatus.Text;
                                    newFlight.IdPromo = tbPromo.Text == string.Empty ? null : Convert.ToInt32(tbPromo.Text);

                                    App.dataBaseContext.Flights.Update(newFlight);
                                    App.dataBaseContext.SaveChanges();

                                    Close();
                                }
                            }
                        }
                    }
                }
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

