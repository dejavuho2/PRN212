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
    /// <summary>
    /// Interaction logic for CustomerProfile.xaml
    /// </summary>
    public partial class CustomerProfile : Window
    {
        private Customer currentUser;
        private readonly ICustomerService iCustomerService;

        public CustomerProfile(Customer user)
        {
            InitializeComponent();
            currentUser = user;
            iCustomerService = new CustomerService();
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            txtCustomerID.Text = currentUser.CustomerId.ToString();
            txtCustomerFullName.Text = currentUser.CustomerFullName;
            txtTelephone.Text = currentUser.Telephone;
            txtEmailAddress.Text = currentUser.EmailAddress;

            if (currentUser.CustomerBirthday.HasValue)
            {
                dpCustomerBirthday.SelectedDate = currentUser.CustomerBirthday.Value.ToDateTime(TimeOnly.MinValue);
            }
            else
            {
                dpCustomerBirthday.SelectedDate = DateTime.MinValue; // Or another default value
            }

            cboCustomerStatus.SelectedIndex = currentUser.CustomerStatus == 1 ? 0 : 1;
            pwdPassword.Text = currentUser.Password;
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentUser.CustomerFullName = txtCustomerFullName.Text;
                currentUser.Telephone = txtTelephone.Text;
                currentUser.EmailAddress = txtEmailAddress.Text;

                // Check if SelectedDate has value before accessing .Value
                if (dpCustomerBirthday.SelectedDate.HasValue)
                {
                    currentUser.CustomerBirthday = DateOnly.FromDateTime(dpCustomerBirthday.SelectedDate.Value);
                }
                else
                {
                    // Handle case where SelectedDate is null, maybe show an error or set a default value
                    // Example:
                    MessageBox.Show("Please select a valid date for Customer Birthday.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Exit the method without updating or continuing
                }

                currentUser.CustomerStatus = cboCustomerStatus.SelectedIndex == 0 ? (byte)1 : (byte)0;
                currentUser.Password = pwdPassword.Text;

                iCustomerService.UpdateCustomer(currentUser);
                LoadUserProfile();
                MessageBox.Show("Profile updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBookingReservation_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BookingReservationWindow bookingReservationWindow = new BookingReservationWindow(currentUser);
            bookingReservationWindow.Show();
        }

        private void OpenRoomBookingWindow_Click(object sender, RoutedEventArgs e)
        {
            var roomBookingWindow = new RoomBookingWindow(currentUser);
            roomBookingWindow.ShowDialog();
        }
    }
}
