﻿using BusinessOjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class RoomInformationDAO
    {
        public static List<RoomInformation> GetRoomInformations()
        {
            var listRoomInformation = new List<RoomInformation>();
            try
            {
                using var db = new FuminiHotelManagementContext();
                listRoomInformation = db.RoomInformations.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listRoomInformation;
        }

        public static void SaveRoomInformation(RoomInformation roomInformation)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                db.RoomInformations.Add(roomInformation);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void UpdateRoomInformation(RoomInformation roomInformation)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                db.Entry(roomInformation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteRoomInformation(RoomInformation roomInformation)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                var ri =
                    db.RoomInformations.SingleOrDefault(r => r.RoomId == roomInformation.RoomId);
                if (ri != null) {
                    db.RoomInformations.Remove(ri);
                    db.SaveChanges();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static RoomInformation? GetRoomInformationById(int id)
        {
            using var db = new FuminiHotelManagementContext();
            return db.RoomInformations.FirstOrDefault(r => r.RoomId == id);
        }
    }
}
