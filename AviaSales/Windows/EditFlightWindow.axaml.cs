using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
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
        tbDepartureTime.SelectedDate = Convert.ToDateTime(flight.DepartureTime);
        tbArrivalTime.SelectedDate = Convert.ToDateTime(flight.ArrivalTime);
        tbFlightTime.Text = flight.FlightTime.ToString();
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
        tbDepartureTime.SelectedDate == null ||
        tbArrivalTime.SelectedDate == null ||
        tbFlightTime.Text == string.Empty ||
        tbPrice.Text == string.Empty ||
        tbSeatNumber.Text == string.Empty)
        {
            return;
        }
        else
        {
            currentFlight.Airline = tbAirline.Text;
            currentFlight.Aircraft = tbAircraft.Text;
            currentFlight.DepartureCity = tbDepartureCity.Text;
            currentFlight.ArrivalCity = tbArrivalCity.Text;

            currentFlight.DepartureTime = tbDepartureTime.SelectedDate.HasValue
                ? DateOnly.FromDateTime(tbDepartureTime.SelectedDate.Value.DateTime)
                : null;
            currentFlight.ArrivalTime = tbArrivalTime.SelectedDate.HasValue
                ? DateOnly.FromDateTime(tbArrivalTime.SelectedDate.Value.DateTime)
                : null;

            currentFlight.FlightTime = Convert.ToInt32(tbFlightTime.Text);
            currentFlight.Price = Convert.ToInt32(tbPrice.Text);
            currentFlight.Class = tbClass.Text;
            currentFlight.SeatNumber = Convert.ToInt32(tbSeatNumber.Text);
            currentFlight.Status = tbStatus.Text;
            currentFlight.IdPromo = tbPromo.Text == string.Empty ? Convert.ToInt32(tbPromo.Text) : null;

            App.dataBaseContext.Flights.Update(currentFlight);
            App.dataBaseContext.SaveChanges();

            Close();
        }
    }
}