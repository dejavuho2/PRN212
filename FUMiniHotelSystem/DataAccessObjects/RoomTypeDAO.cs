using BusinessOjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class RoomTypeDAO
    {
        public static List<RoomType> GetRoomTypes()
        {
            var listRoomType = new List<RoomType>();
            try
            {
                using var db = new FuminiHotelManagementContext();
                listRoomType = db.RoomTypes.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listRoomType;
        }

        public static RoomType? GetRoomTypeById(int id)
        {
            using var db = new FuminiHotelManagementContext();
            return db.RoomTypes.FirstOrDefault(rt => rt.RoomTypeId == id);
        }
    }
}
