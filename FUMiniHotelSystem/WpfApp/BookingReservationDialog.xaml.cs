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

namespace WpfApp    
{
    public partial class BookingReservationDialog : Window
    {

        // Property to expose the current reservation
        public BookingReservation CurrentReservation { get; private set; }

        public BookingReservationDialog(BookingReservation? reservation = null)
        {
            InitializeComponent();

            CurrentReservation = reservation ?? new BookingReservation();

            // Bind data to controls
            dpBookingDate.SelectedDate = CurrentReservation.BookingDate != null ? (DateTime?)CurrentReservation.BookingDate.Value.ToDateTime(TimeOnly.MinValue) : null;
            txtTotalPrice.Text = CurrentReservation.TotalPrice?.ToString();
            txtCustomerId.Text = CurrentReservation.CustomerId.ToString();
            cboBookingStatus.SelectedIndex = CurrentReservation.BookingStatus == 1 ? 0 : 1; // Assuming BookingStatus is byte

            DataContext = CurrentReservation;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                // Update current reservation object
                CurrentReservation.BookingDate = dpBookingDate.SelectedDate != null ? DateOnly.FromDateTime(dpBookingDate.SelectedDate.Value) : (DateOnly?)null;
                CurrentReservation.TotalPrice = string.IsNullOrWhiteSpace(txtTotalPrice.Text) ? null : (decimal?)Convert.ToDecimal(txtTotalPrice.Text);
                CurrentReservation.CustomerId = Convert.ToInt32(txtCustomerId.Text);
                CurrentReservation.BookingStatus = (byte)(cboBookingStatus.SelectedIndex == 0 ? 1 : 0); // Assuming ComboBoxItem Tag values are "1" and "0"

                DialogResult = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private bool ValidateInputs()
        {
            decimal totalPrice;
            int customerId;

            if (dpBookingDate.SelectedDate == null)
            {
                MessageBox.Show("Booking Date is required.", "Input Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!decimal.TryParse(txtTotalPrice.Text, out totalPrice) && !string.IsNullOrWhiteSpace(txtTotalPrice.Text))
            {
                MessageBox.Show("Total Price must be a valid decimal number.", "Input Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(txtCustomerId.Text, out customerId))
            {
                MessageBox.Show("Customer ID must be a valid integer.", "Input Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (cboBookingStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Booking Status is required.", "Input Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
