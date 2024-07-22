using BusinessOjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomInformationService : IRoomInformationService
    {
        private readonly IRoomInformationRepository iRoomInformationRepository;

        public RoomInformationService()
        {
            iRoomInformationRepository = new RoomInformationRepository();
        }

        public List<RoomInformation> GetRoomInformationList()
        {
            return iRoomInformationRepository.GetRoomInformation().ToList();
        }

        public RoomInformation? GetRoomInformationById(int id)
        {
            return iRoomInformationRepository.GetRoomInformationById(id);
        }

        public void AddRoomInformation(RoomInformation roomInformation)
        {
            iRoomInformationRepository.SaveRoomInformation(roomInformation);
        }

        public void UpdateRoomInformation(RoomInformation roomInformation)
        {
            iRoomInformationRepository.UpdateRoomInformation(roomInformation);
        }

        public void DeleteRoomInformation(RoomInformation roomInformation)
        {
            iRoomInformationRepository.DeleteRoomInformation(roomInformation);
        }

    }
}
