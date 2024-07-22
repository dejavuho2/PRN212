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
    /// Interaction logic for RoomDialog.xaml
    /// </summary>
    public partial class RoomDialog : Window
    {
        public RoomInformation Room { get; private set; }

        public RoomDialog(RoomInformation? room = null)
        {
            InitializeComponent();
            Room = room ?? new RoomInformation();
            DataContext = Room;

            if (room != null)
            {
                txtRoomNumber.Text = room.RoomNumber;
                txtRoomDetailDescription.Text = room.RoomDetailDescription;
                txtRoomMaxCapacity.Text = room.RoomMaxCapacity.ToString();
                txtRoomTypeID.Text = room.RoomTypeId.ToString();
                cboRoomStatus.SelectedIndex = room.RoomStatus == 1 ? 0 : 1;
                txtRoomPricePerDay.Text = room.RoomPricePerDay.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                Room.RoomNumber = txtRoomNumber.Text;
                Room.RoomDetailDescription = txtRoomDetailDescription.Text;
                Room.RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text);
                Room.RoomTypeId = int.Parse(txtRoomTypeID.Text);
                Room.RoomStatus = (byte)((cboRoomStatus.SelectedItem as ComboBoxItem)?.Tag.ToString() == "1" ? 1 : 0);
                Room.RoomPricePerDay = decimal.Parse(txtRoomPricePerDay.Text);

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

            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                errorMessage.AppendLine("Room Number is required.");
            }

            if (string.IsNullOrWhiteSpace(txtRoomDetailDescription.Text))
            {
                errorMessage.AppendLine("Room Detail Description is required.");
            }

            if (string.IsNullOrWhiteSpace(txtRoomMaxCapacity.Text))
            {
                errorMessage.AppendLine("Room Max Capacity is required.");
            }
            else if (!int.TryParse(txtRoomMaxCapacity.Text, out _))
            {
                errorMessage.AppendLine("Room Max Capacity must be a valid number.");
            }

            if (string.IsNullOrWhiteSpace(txtRoomTypeID.Text))
            {
                errorMessage.AppendLine("Room Type ID is required.");
            }
            else if (!int.TryParse(txtRoomTypeID.Text, out _))
            {
                errorMessage.AppendLine("Room Type ID must be a valid number.");
            }

            if (cboRoomStatus.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Room Status is required.");
            }

            if (string.IsNullOrWhiteSpace(txtRoomPricePerDay.Text))
            {
                errorMessage.AppendLine("Room Price Per Day is required.");
            }
            else if (!decimal.TryParse(txtRoomPricePerDay.Text, out _))
            {
                errorMessage.AppendLine("Room Price Per Day must be a valid decimal number.");
            }

            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage.ToString(), "Input Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
