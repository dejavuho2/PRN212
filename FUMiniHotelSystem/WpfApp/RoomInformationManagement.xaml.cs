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
    /// Interaction logic for RoomInformationManagement.xaml
    /// </summary>
    public partial class RoomInformationManagement : Window
    {
        private readonly IRoomInformationService roomService;
        private readonly IBookingDetailService bookingDetailService;

        public RoomInformationManagement()
        {
            InitializeComponent();
            roomService = new RoomInformationService();
            bookingDetailService = new BookingDetailService();
        }

        public void LoadRoomList()
        {
            try
            {
                var roomList = roomService.GetRoomInformationList();
                dgData.ItemsSource = roomList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on loading room list");
            }
            finally
            {
                //ResetInput();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRoomList();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            RoomDialog dialog = new RoomDialog();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    roomService.AddRoomInformation(dialog.Room);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    LoadRoomList();
                }
            }
        }

        //private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (dgData.SelectedItem == null)
        //        return;

        //    if (dgData.SelectedItem is RoomInformation selectedRoom)
        //    {
        //        txtRoomID.Text = selectedRoom.RoomId.ToString();
        //        txtRoomNumber.Text = selectedRoom.RoomNumber ?? "";
        //        txtRoomDetailDescription.Text = selectedRoom.RoomDetailDescription ?? "";
        //        txtRoomMaxCapacity.Text = selectedRoom.RoomMaxCapacity.ToString();
        //        txtRoomTypeID.Text = selectedRoom.RoomTypeId.ToString();
        //        cboRoomStatus.SelectedIndex = selectedRoom.RoomStatus == 1 ? 0 : 1;
        //        txtRoomPricePerDay.Text = selectedRoom.RoomPricePerDay.ToString();
        //    }
        //}

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomInformation? selectedRoom = dgData.SelectedItem as RoomInformation;
                if (selectedRoom != null)
                {
                    RoomDialog dialog = new RoomDialog(selectedRoom);
                    if (dialog.ShowDialog() == true)
                    {
                        roomService.UpdateRoomInformation(dialog.Room);
                        LoadRoomList();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem is RoomInformation selectedRoom)
            {
                var result = MessageBox.Show($"Are you sure you want to delete Room {selectedRoom.RoomNumber}?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        // Check if the room is part of any booking detail
                        if (bookingDetailService.IsRoomInBookingDetail(selectedRoom.RoomId))
                        {
                            // If the room is part of a booking detail, change its status
                            selectedRoom.RoomStatus = 0; // Assuming 0 means inactive or not available
                            roomService.UpdateRoomInformation(selectedRoom);
                            MessageBox.Show("Room is part of a booking detail and its status has been updated.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            // If the room is not part of any booking detail, delete it
                            roomService.DeleteRoomInformation(selectedRoom);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        LoadRoomList();
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select a room!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        //private void ResetInput()
        //{
        //    txtRoomID.Text = "";
        //    txtRoomNumber.Text = "";
        //    txtRoomDetailDescription.Text = "";
        //    txtRoomMaxCapacity.Text = "";
        //    txtRoomTypeID.Text = "";
        //    cboRoomStatus.SelectedIndex = -1;
        //    txtRoomPricePerDay.Text = "";
        //}
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
            // No action needed as we are already in the Room Information Management page
        }

        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {
            // Logic to navigate to Create Report page
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
    }
}