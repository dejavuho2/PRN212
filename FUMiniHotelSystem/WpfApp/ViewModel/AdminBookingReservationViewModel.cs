using BusinessOjects.Models;
using DataAccessObjects;
using Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp.ViewModel
{
    public class AdminBookingReservationViewModel : INotifyPropertyChanged
    {
        private readonly IBookingReservationService bookingReservationService;

        public ObservableCollection<BookingReservation> BookingReservations { get; set; }
        public ObservableCollection<BookingDetail> BookingDetails { get; set; }

        private BookingReservation? selectedReservation;
        public BookingReservation? SelectedReservation
        {
            get { return selectedReservation; }
            set
            {
                selectedReservation = value;
                OnPropertyChanged();
                LoadBookingDetails();
            }
        }

        public AdminBookingReservationViewModel()
        {
            bookingReservationService = new BookingReservationService();
            BookingReservations = new ObservableCollection<BookingReservation>(BookingReservationDAO.GetBookingReservations());
            BookingDetails = new ObservableCollection<BookingDetail>();
        }

        private void LoadBookingDetails()
        {
            if (SelectedReservation != null)
            {
                BookingDetails.Clear();
                foreach (var detail in SelectedReservation.BookingDetails)
                {
                    BookingDetails.Add(detail);
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
