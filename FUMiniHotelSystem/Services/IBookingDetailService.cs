using BusinessOjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookingDetailService
    {
        void AddBookingDetail(BookingDetail bookingDetail);
        void UpdateBookingDetail(BookingDetail bookingDetail);
        void DeleteBookingDetail(BookingDetail bookingDetail);

        List<BookingDetail> GetBookingDetailList();

        BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId);

        bool IsRoomInBookingDetail(int roomId);
    }
}
