using BusinessOjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingDetailDAO
    {
        public static List<BookingDetail> GetBookingDetails()
        {
            var listBookingDetail = new List<BookingDetail>();
            try
            {
                using var db = new FuminiHotelManagementContext();
                listBookingDetail = db.BookingDetails.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listBookingDetail;
        }

        public static void SaveBookingDetail(BookingDetail bookingDetail)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                db.BookingDetails.Add(bookingDetail);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void UpdateBookingDetail(BookingDetail bookingDetail)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                db.Entry(bookingDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteBookingDetail(BookingDetail bookingDetail)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                var bd = db.BookingDetails.SingleOrDefault(b => b.BookingReservationId == bookingDetail.BookingReservationId && b.RoomId == bookingDetail.RoomId);
                if (bd != null)
                {
                    db.BookingDetails.Remove(bd);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static BookingDetail? GetBookingDetailById(int bookingReservationId, int roomId)
        {
            using var db = new FuminiHotelManagementContext();
            return db.BookingDetails.FirstOrDefault(b => b.BookingReservationId == bookingReservationId && b.RoomId == roomId);
        }

        public static bool IsRoomInBookingDetail(int roomId)
        {
            using var db = new FuminiHotelManagementContext();
            return db.BookingDetails.Any(bd => bd.RoomId == roomId);
        }
    }
}
