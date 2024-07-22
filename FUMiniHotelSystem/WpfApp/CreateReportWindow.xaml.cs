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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CreateReportWindow.xaml
    /// </summary>
    public partial class CreateReportWindow : Window
    {

        private readonly IBookingReservationService bookingReservationService;

        public CreateReportWindow()
        {
            InitializeComponent();
            bookingReservationService = new BookingReservationService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load initial data if needed
        }

        private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = dpStartDate.SelectedDate ?? DateTime.MinValue;
            DateTime endDate = dpEndDate.SelectedDate ?? DateTime.MaxValue;

            if (startDate == DateTime.MinValue || endDate == DateTime.MaxValue)
            {
                MessageBox.Show("Please select both Start Date and End Date.");
                return;
            }

            var bookings = bookingReservationService.GetBookingReservationListByTime(startDate, endDate)
                .Select(br => new
                {
                    br.BookingReservationId,
                    BookingDate = br.BookingDate?.ToString("dd/MM/yyyy"),
                    TotalPrice = br.TotalPrice.HasValue ? $"{br.TotalPrice:C}" : "",
                    BookingStatus = br.BookingStatus == 1 ? "Confirmed" : "Pending"
                }).ToList();

            dgReportData.ItemsSource = bookings;
        }



        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnManageCustomerInfo_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to Manage Customer Information page
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void btnManageRoomInfo_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to Manage Room Information page
            this.Hide();
            RoomInformationManagement manageRoomInfoWindow = new RoomInformationManagement();
            manageRoomInfoWindow.Show();
        }

        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to Create Report page
            // No action needed as we are already in the Room Information Management page
        }

        private void btnCreateBookingReservation_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminBookingReservationWindow adminBookingReservationWindow = new AdminBookingReservationWindow();
            adminBookingReservationWindow.Show();
        }
    }
}
