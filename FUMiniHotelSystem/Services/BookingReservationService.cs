using BusinessOjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingReservationService : IBookingReservationService
    {

        private readonly IBookingReservationRepository iBookingReservationRepository;

        public BookingReservationService()
        {
            iBookingReservationRepository = new BookingReservationRepository();
        }

        public List<BookingReservation> GetBookingReservationList()
        {
            return iBookingReservationRepository.GetBookingReservations().ToList();
        }

        public BookingReservation? GetBookingReservationById(int id)
        {
            return iBookingReservationRepository.GetBookingReservationById(id);
        }

        public void AddBookingReservation(BookingReservation bookingReservation)
        {
            iBookingReservationRepository.SaveBookingReservation(bookingReservation);
        }

        public void UpdateBookingReservation(BookingReservation bookingReservation)
        {
            iBookingReservationRepository.UpdateBookingReservation(bookingReservation);
        }

        public void DeleteBookingReservation(BookingReservation bookingReservation)
        {
            iBookingReservationRepository.DeleteBookingReservation(bookingReservation);
        }

        public List<BookingReservation>? GetBookingReservationListByTime(DateTime startDate, DateTime endDate)
        {
            return iBookingReservationRepository.GetBookingReservationsByTime(startDate, endDate);
        }

        public List<BookingDetail> GetBookingDetailsByReservationId(int reservationId)
        {
            return iBookingReservationRepository.GetBookingDetailsByReservationId((int)reservationId);
        }
    }
}
