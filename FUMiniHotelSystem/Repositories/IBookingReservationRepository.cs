using BusinessOjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingReservationRepository
    {
        List<BookingReservation> GetBookingReservations();

        void SaveBookingReservation(BookingReservation bookingReservation);

        void UpdateBookingReservation(BookingReservation bookingReservation);

        void DeleteBookingReservation(BookingReservation bookingReservation);

        BookingReservation? GetBookingReservationById(int id);

        List<BookingReservation>? GetBookingReservationsByTime(DateTime startDate, DateTime endDate);

        List<BookingDetail> GetBookingDetailsByReservationId(int reservationId);
    }
}
