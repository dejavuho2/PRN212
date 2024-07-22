using BusinessOjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoomTypeRepository
    {
        List<RoomType> GetRoomTypes();

        RoomType? GetRoomTypeById(int id);

    }
}
