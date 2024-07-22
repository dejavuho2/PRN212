using BusinessOjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public List<BookingDetail> GetBookingDetails() => BookingDetailDAO.GetBookingDetails();

        public BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId) => BookingDetailDAO.GetBookingDetailById(bookingReservationId, roomId);

        public void SaveBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.SaveBookingDetail(bookingDetail);

        public void UpdateBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.UpdateBookingDetail(bookingDetail);

        public void DeleteBookingDetail(BookingDetail bookingDetail) => BookingDetailDAO.DeleteBookingDetail(bookingDetail);

        public bool IsRoomInBookingDetail(int roomId) => BookingDetailDAO.IsRoomInBookingDetail(roomId);
    }
}
