using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Link_Inventory.Data;
using Link_Inventory.Models.Entities;

namespace Link_Inventory.Models.Repositories
{
    public class ItemUserRepository : IItemUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ISerializedItemRepository _serializedItemRepository;
      

        public ItemUserRepository(ApplicationDbContext applicationDbContext, ISerializedItemRepository serializedItemRepository)
        {
            _applicationDbContext = applicationDbContext;
            _serializedItemRepository = serializedItemRepository;
        
        }

        public IEnumerable<ItemUser> AllItemsUsers
        {
            get { return _applicationDbContext.ItemUsers; }
        }

        public ItemUser GetItemUserBySerializedItemId(int id)
        {
            var serializedItem = _serializedItemRepository.GetSerializedItemById(id);
            int userId = serializedItem.ItemUserId;

            var itemUser = _applicationDbContext.ItemUsers.First(i => i.Id == userId);

            return itemUser;
        }

        public Room GetRoomBySerializedItemId(int id)
        {
            var serializedItem = _serializedItemRepository.GetSerializedItemById(id);
            int roomId = serializedItem.RoomId;

            var room = _applicationDbContext.Rooms.First(i => i.Id == roomId);

            return room;
        }
    }
}
