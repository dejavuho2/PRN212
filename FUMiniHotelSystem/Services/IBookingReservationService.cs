using BusinessOjects.Models;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IBookingReservationService
    {
        void AddBookingReservation(BookingReservation bookingReservation);
        void UpdateBookingReservation(BookingReservation bookingReservation);
        void DeleteBookingReservation(BookingReservation bookingReservation);
        List<BookingReservation> GetBookingReservationList();
        List<BookingReservation>? GetBookingReservationListByTime(DateTime startDate, DateTime endDate);
        BookingReservation? GetBookingReservationById(int id);
        List<BookingDetail> GetBookingDetailsByReservationId(int reservationId);
    }
}
