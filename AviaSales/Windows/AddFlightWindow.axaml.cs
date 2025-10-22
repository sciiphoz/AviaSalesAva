using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
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

        if (tbAirline.Text == string.Empty || tbAircraft.Text == string.Empty ||
        tbDepartureCity.Text == string.Empty ||
        tbArrivalCity.Text == string.Empty ||
        tbDepartureTime.SelectedDate == null ||
        tbArrivalTime.SelectedDate == null ||
        tbPrice.Text == string.Empty ||
        tbSeatNumber.Text == string.Empty)
        {
            return;
        }
        else
        {
            if (tbDepartureCity.Text == tbArrivalCity.Text)
            {
                return;
            }
            else
            {
                if (tbDepartureTime.SelectedDate == tbArrivalTime.SelectedDate)
                {
                    return;
                }
                else
                {
                    if (Convert.ToInt32(tbFlightTime.Text) <= 0)
                    {
                        return;
                    }
                    else
                    {
                        if (Convert.ToInt32(tbPrice.Text) <= 0)
                        {
                            return;
                        }
                        else
                        {
                            if (Convert.ToInt32(tbSeatNumber.Text) <= 0)
                            {
                                return;
                            }
                            else
                            {
                                newFlight.IdFlight = Convert.ToInt32(App.dataBaseContext.Flights.Max(x => x.IdFlight).ToString()) + 1;
                                newFlight.Airline = tbAirline.Text;
                                newFlight.Aircraft = tbAircraft.Text;
                                newFlight.DepartureCity = tbDepartureCity.Text;
                                newFlight.ArrivalCity = tbArrivalCity.Text;

                                newFlight.DepartureTime = DateTime.Parse(tbDepartureTime.SelectedDate.ToString());

                                newFlight.ArrivalTime = DateTime.Parse(tbArrivalTime.SelectedDate.ToString());

                                newFlight.Price = Convert.ToInt32(tbPrice.Text);
                                newFlight.Class = tbClass.Text;
                                newFlight.SeatNumber = Convert.ToInt32(tbSeatNumber.Text);
                                newFlight.Status = tbStatus.Text;
                                newFlight.IdPromo = tbPromo.Text == string.Empty ? Convert.ToInt32(tbPromo.Text) : null;

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
}

