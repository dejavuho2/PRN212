using BusinessOjects.Models;
using Services;
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
using WpfApp.ViewModel;

namespace WpfApp
{
    public partial class AdminBookingReservationWindow : Window
    {
        private readonly IBookingReservationService bookingReservationService;
        private readonly AdminBookingReservationViewModel viewModel;

        public AdminBookingReservationWindow()
        {
            InitializeComponent();
            viewModel = new AdminBookingReservationViewModel();
            DataContext = viewModel;
            bookingReservationService = new BookingReservationService();
            dgBookingReservations.ItemsSource = viewModel.BookingReservations;
            dgBookingDetails.ItemsSource = viewModel.BookingDetails;
        }

        private void LoadBookingReservations()
        {
            try
            {
                dgBookingReservations.ItemsSource = bookingReservationService.GetBookingReservationList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking reservations: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new BookingReservationDialog();
            if (dialog.ShowDialog() == true)
            {
                var newReservation = dialog.CurrentReservation;
                try
                {
                    bookingReservationService.AddBookingReservation(newReservation);
                    LoadBookingReservations();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgBookingReservations.SelectedItem is BookingReservation selectedReservation)
            {
                var dialog = new BookingReservationDialog(selectedReservation);
                if (dialog.ShowDialog() == true)
                {
                    var updatedReservation = dialog.CurrentReservation;
                    try
                    {
                        bookingReservationService.UpdateBookingReservation(updatedReservation);
                        LoadBookingReservations();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating booking reservation: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select a booking reservation!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgBookingReservations.SelectedItem is BookingReservation selectedReservation)
            {
                var result = MessageBox.Show($"Are you sure you want to delete Booking Reservation {selectedReservation.BookingReservationId}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        bookingReservationService.DeleteBookingReservation(selectedReservation);
                        LoadBookingReservations();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting booking reservation: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select a booking reservation!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgBookingReservations_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgBookingReservations.SelectedItem is BookingReservation selectedReservation)
            {
                viewModel.SelectedReservation = selectedReservation;
            }
        }

        private void btnCreateBookingReservation_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to Manage Customer Information page
        }

        private void btnManageRoomInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RoomInformationManagement manageRoomInfoWindow = new RoomInformationManagement();
            manageRoomInfoWindow.Show();
        }

        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CreateReportWindow createReportWindow = new CreateReportWindow();
            createReportWindow.Show();
        }

        private void btnManageCustomerInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
