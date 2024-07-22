using BusinessOjects.Models;
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
    /// Interaction logic for CustomerDialog.xaml
    /// </summary>
    public partial class CustomerDialog : Window
    {
        public Customer Customer { get; private set; }

        public CustomerDialog(Customer? customer = null)
        {
            InitializeComponent();
            Customer = customer ?? new Customer();
            DataContext = Customer;

            if (customer != null)
            {
                txtCustomerFullName.Text = customer.CustomerFullName;
                txtTelePhone.Text = customer.Telephone;
                txtEmailAddress.Text = customer.EmailAddress;
                dpCustomerBirthday.SelectedDate = customer.CustomerBirthday?.ToDateTime(TimeOnly.MinValue);
                cboCustomerStatus.SelectedIndex = customer.CustomerStatus == 1 ? 0 : 1;
                pwdPassword.Password = customer.Password;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                Customer.CustomerFullName = txtCustomerFullName.Text;
                Customer.Telephone = txtTelePhone.Text;
                Customer.EmailAddress = txtEmailAddress.Text;
                Customer.CustomerBirthday = dpCustomerBirthday.SelectedDate != null ? DateOnly.FromDateTime(dpCustomerBirthday.SelectedDate.Value) : null;
                Customer.CustomerStatus = (cboCustomerStatus.SelectedItem as ComboBoxItem)?.Tag.ToString() == "1" ? (byte)1 : (byte)0;
                Customer.Password = pwdPassword.Password;

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
            StringBuilder errorMessage = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtCustomerFullName.Text))
            {
                errorMessage.AppendLine("Customer Full Name is required.");
            }

            if (string.IsNullOrWhiteSpace(txtTelePhone.Text))
            {
                errorMessage.AppendLine("Telephone is required.");
            }

            if (string.IsNullOrWhiteSpace(txtEmailAddress.Text))
            {
                errorMessage.AppendLine("Email Address is required.");
            }
            else if (!IsValidEmail(txtEmailAddress.Text))
            {
                errorMessage.AppendLine("Email Address is not valid.");
            }

            if (dpCustomerBirthday.SelectedDate == null)
            {
                errorMessage.AppendLine("Customer Birthday is required.");
            }

            if (cboCustomerStatus.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Customer Status is required.");
            }

            if (string.IsNullOrWhiteSpace(pwdPassword.Password))
            {
                errorMessage.AppendLine("Password is required.");
            }

            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage.ToString(), "Input Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}