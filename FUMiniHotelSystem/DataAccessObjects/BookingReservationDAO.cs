using BusinessOjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BookingReservationDAO
    {
        public static List<BookingReservation> GetBookingReservations()
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                return db.BookingReservations.Include(br => br.BookingDetails).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void SaveBookingReservation(BookingReservation bookingReservation)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                db.BookingReservations.Add(bookingReservation);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void UpdateBookingReservation(BookingReservation bookingReservation)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                db.Entry(bookingReservation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteBookingReservation(BookingReservation bookingReservation)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                var br =
                    db.BookingReservations.SingleOrDefault(b => b.BookingReservationId == bookingReservation.BookingReservationId);
                if (br != null)
                {
                    db.BookingReservations.Remove(br);
                    db.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static BookingReservation? GetBookingReservationById(int id)
        {
            using var db = new FuminiHotelManagementContext();
            return db.BookingReservations.FirstOrDefault(b => b.BookingReservationId == id);
        }

        public static List<BookingReservation> GetBookingReservationsByTime(DateTime startDate, DateTime endDate)
        {
            var listBookingReservation = new List<BookingReservation>();
            try
            {
                using var db = new FuminiHotelManagementContext();
                DateOnly start = DateOnly.FromDateTime(startDate);
                DateOnly end = DateOnly.FromDateTime(endDate);

                listBookingReservation = db.BookingReservations
                    .Where(br => br.BookingDate.HasValue && br.BookingDate.Value >= start && br.BookingDate.Value <= end)
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listBookingReservation;
        }
    }
}
