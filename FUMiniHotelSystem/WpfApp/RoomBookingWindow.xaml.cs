using BusinessOjects.Models;
using DataAccessLayer;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for RoomBookingWindow.xaml
    /// </summary>
    public partial class RoomBookingWindow : Window
    {
        private Customer _currentCustomer;

        public RoomBookingWindow(Customer currentCustomer)
        {
            InitializeComponent();
            _currentCustomer = currentCustomer;
            LoadRoomInformation();
        }

        private void LoadRoomInformation()
        {
            try
            {
                var allRooms = RoomInformationDAO.GetRoomInformations();

                var availableRooms = allRooms
                    .Where(room => room.RoomStatus == 0)
                    .ToList();

                RoomListBox.ItemsSource = availableRooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading room information: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BookRoomButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedRooms = RoomListBox.SelectedItems.Cast<RoomInformation>().ToList();
                if (selectedRooms.Count == 0)
                {
                    MessageBox.Show("Please select at least one room to book.", "No Room Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (StartDatePicker.SelectedDate == null || EndDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Please select both start date and end date.", "Date Missing", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var startDate = StartDatePicker.SelectedDate.Value;
                var endDate = EndDatePicker.SelectedDate.Value;
                var today = DateTime.Today;

                if (startDate < today || endDate < today)
                {
                    MessageBox.Show("Start date and end date must be greater than or equal to today's date.", "Invalid Dates", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (startDate >= endDate)
                {
                    MessageBox.Show("End date must be after start date.", "Invalid Dates", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var bookingReservation = new BookingReservation
                {
                    CustomerId = _currentCustomer.CustomerId,
                    BookingDate = DateOnly.FromDateTime(DateTime.Now),
                    BookingStatus = 1 // Assuming 1 means 'booked'
                };

                int totalDays = (endDate - startDate).Days;
                bookingReservation.TotalPrice = selectedRooms.Sum(room => room.RoomPricePerDay * totalDays);
                BookingReservationDAO.SaveBookingReservation(bookingReservation);

                foreach (var room in selectedRooms)
                {
                    var bookingDetail = new BookingDetail
                    {
                        BookingReservationId = bookingReservation.BookingReservationId,
                        RoomId = room.RoomId,
                        StartDate = DateOnly.FromDateTime(startDate),
                        EndDate = DateOnly.FromDateTime(endDate),
                        ActualPrice = room.RoomPricePerDay * totalDays
                    };
                    BookingDetailDAO.SaveBookingDetail(bookingDetail);
                        
                    RoomInformationDAO.UpdateRoomStatus(room.RoomId, 1);
                }

                MessageBox.Show("Rooms successfully booked!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while booking the rooms: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
