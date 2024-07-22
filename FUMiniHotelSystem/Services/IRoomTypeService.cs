using BusinessOjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRoomTypeService
    {

        List<RoomType> GetRoomTypeList();

        RoomType? GetRoomTypeById(int id);
    }
}
