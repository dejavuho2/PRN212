using BusinessOjects.Models;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomInformationRepository : IRoomInformationRepository
    {
        public List<RoomInformation> GetRoomInformation() => RoomInformationDAO.GetRoomInformations();

        public RoomInformation? GetRoomInformationById(int roomID) => RoomInformationDAO.GetRoomInformationById(roomID);

        public void SaveRoomInformation(RoomInformation roomInformation) => RoomInformationDAO.SaveRoomInformation(roomInformation);

        public void UpdateRoomInformation(RoomInformation roomInformation) => RoomInformationDAO.UpdateRoomInformation(roomInformation);

        public void DeleteRoomInformation(RoomInformation roomInformation) => RoomInformationDAO.DeleteRoomInformation(roomInformation);

    }
}
