using BusinessOjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomInformationRepository
    {
        List<RoomInformation> GetRoomInformation();

        void SaveRoomInformation(RoomInformation roomInformation);

        void UpdateRoomInformation(RoomInformation roomInformation);

        void DeleteRoomInformation(RoomInformation roomInformation);

        RoomInformation? GetRoomInformationById(int id);

    }
}
