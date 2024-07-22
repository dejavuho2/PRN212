using BusinessOjects.Models;
using Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class BookingReservationWindow : Window
    {
        private Customer currentUser;
        private readonly IBookingReservationService bookingReservationService;
        public ObservableCollection<BookingDetail> BookingDetails { get; set; }
        public BookingReservation? SelectedReservation { get; set; }

        public BookingReservationWindow(Customer user)
        {
            InitializeComponent();
            currentUser = user;
            bookingReservationService = new BookingReservationService();
            BookingDetails = new ObservableCollection<BookingDetail>();
            dgBookingDetails.ItemsSource = BookingDetails;
            LoadBookingHistory();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadBookingHistory()
        {
            if (currentUser == null || currentUser.BookingReservations == null)
            {
                MessageBox.Show("Invalid user data. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var bookingReservations = bookingReservationService.GetBookingReservationList()
                                  .Where(br => br.CustomerId == currentUser.CustomerId)
                                  .Select(br => new
                                  {
                                      br.BookingReservationId,
                                      br.BookingDate,
                                      br.TotalPrice,
                                      BookingStatus = br.BookingStatus == 1 ? "Confirmed" : "Pending"
                                  }).ToList();

            dgBookingHistory.ItemsSource = bookingReservations;
        }

        private void dgBookingHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedReservation = dgBookingHistory.SelectedItem as dynamic;

            if (selectedReservation != null)
            {
                SelectedReservation = bookingReservationService.GetBookingReservationById(selectedReservation.BookingReservationId);
                LoadBookingDetails();
            }
        }

        private void LoadBookingDetails()
        {
            if (SelectedReservation != null)
            {
                var bookingDetails = bookingReservationService.GetBookingDetailsByReservationId(SelectedReservation.BookingReservationId);
                BookingDetails.Clear();
                foreach (var detail in bookingDetails)
                {
                    BookingDetails.Add(detail);
                }
            }
        }

        private void btnUserProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CustomerProfile customerProfile = new CustomerProfile(currentUser);
            customerProfile.Show();
        }
    }
}
