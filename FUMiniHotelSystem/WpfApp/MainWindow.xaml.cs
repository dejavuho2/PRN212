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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICustomerService iCustomerService;

        public MainWindow()
        {
            InitializeComponent();
            iCustomerService = new CustomerService();
        }

        public void LoadCustomerList()
        {
            try
            {
                var customerList = iCustomerService.GetCustomerList();
                dgData.ItemsSource = customerList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of customers");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomerList();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CustomerDialog dialog = new CustomerDialog();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    iCustomerService.AddCustomer(dialog.Customer);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    LoadCustomerList();
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem is Customer selectedCustomer)
            {
                CustomerDialog dialog = new CustomerDialog(selectedCustomer);
                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        iCustomerService.UpdateCustomer(dialog.Customer);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        LoadCustomerList();
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select a Customer!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem is Customer selectedCustomer)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {selectedCustomer.CustomerFullName}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        iCustomerService.DeleteCustomer(selectedCustomer);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        LoadCustomerList();
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select a Customer!");
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Selection changed logic here
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnManageCustomerInfo_Click(object sender, RoutedEventArgs e)
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

        private void btnCreateBookingReservation_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminBookingReservationWindow adminBookingReservationWindow = new AdminBookingReservationWindow();
            adminBookingReservationWindow.Show();
        }

        // Xử lý sự kiện TextChanged của TextBox tìm kiếm
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = txtSearch.Text.ToLower();
            var filteredList = iCustomerService.GetCustomerList().Where(c => c.CustomerFullName.ToLower().Contains(searchText)).ToList();
            dgData.ItemsSource = filteredList;
        }
    }
}
