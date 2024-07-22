using BusinessOjects.Models;
using Microsoft.Extensions.Configuration;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private readonly ICustomerService iCustomerService;
        private IConfiguration _configuration;

        public LoginWindow()
        {
            InitializeComponent();
            iCustomerService = new CustomerService();
            _configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .Build();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Customer? account = iCustomerService.GetCustomerByEmail(txtUser.Text);
            string? adminEmail = _configuration["DefaultAdminAccount:Email"];
            string? adminPassword = _configuration["DefaultAdminAccount:Password"];

            string enteredEmail = txtUser.Text;
            string enteredPassword = txtPass.Password;

            // Kiểm tra đăng nhập
            if (enteredEmail.Equals(adminEmail, StringComparison.OrdinalIgnoreCase) &&
                enteredPassword.Equals(adminPassword))
            {
                if (enteredEmail.Equals("admin@FUMiniHotelSystem.com", StringComparison.OrdinalIgnoreCase))
                {
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }

            }
            else if (account != null && account.Password != null)
            {
                this.Hide();
                // Tạo CustomerProfile với thông tin tài khoản khách hàng
                CustomerProfile customerProfile = new CustomerProfile(account);
                customerProfile.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
