using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AviaSales.Data;
using System;

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
        tbDepartureTime.SelectedDate = flight.DepartureTime;
        tbArrivalTime.SelectedDate = flight.ArrivalTime;
        tbFlightTime.Text = flight.FlightTime;
        tbPrice.Text = flight.Price;
        tbClass.Text = flight.Class;
        tbSeatNumber.Text = flight.SeatNumber;
        tbStatus.Text = flight.Status;
    }
}