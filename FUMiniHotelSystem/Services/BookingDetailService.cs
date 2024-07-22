using BusinessOjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingDetailService : IBookingDetailService
    {
        private readonly IBookingDetailRepository iBookingDetailRepository;

        public BookingDetailService()
        {
            iBookingDetailRepository = new BookingDetailRepository();
        }

        public List<BookingDetail> GetBookingDetailList()
        {
            return iBookingDetailRepository.GetBookingDetails().ToList();
        }

        public BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId)
        {
            return iBookingDetailRepository.GetBookingDetailById(bookingReservationId, roomId);
        }

        public void AddBookingDetail(BookingDetail bookingDetail)
        {
            iBookingDetailRepository.SaveBookingDetail(bookingDetail);
        }

        public void UpdateBookingDetail(BookingDetail bookingDetail)
        {
            iBookingDetailRepository.UpdateBookingDetail(bookingDetail);
        }

        public void DeleteBookingDetail(BookingDetail bookingDetail)
        {
            iBookingDetailRepository.DeleteBookingDetail(bookingDetail);
        }

        public bool IsRoomInBookingDetail(int roomId)
        {
            return iBookingDetailRepository.IsRoomInBookingDetail(roomId);
        }
    }
}
