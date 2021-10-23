using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Main.Scripts.PUN
{
    public class RoomListingMenu : MonoBehaviourPunCallbacks
    {
        [BoxGroup("Room Listing Setup"), SerializeField, Required] private Transform _content;
        [BoxGroup("Room Listing Setup"), SerializeField, Required] private RoomElement _roomElementPrefab;

        private List<RoomElement> _rooms = new List<RoomElement>();
        
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            if (_roomElementPrefab == null)
            {
                Debug.LogError($"Missing reference {_roomElementPrefab}");
                return;
            }
            
            foreach (RoomInfo info in roomList)
            {
                if (info.RemovedFromList)
                {
                    var index = _rooms.FindIndex(x => x.RoomInfo.Name == info.Name);
                    Destroy(_rooms[index].gameObject);
                    _rooms.RemoveAt(index);
                    continue;
                }
                
                var room = Instantiate(_roomElementPrefab, _content);
                room.SetRoomInfo(info);
                _rooms.Add(room);
            }
        }
    }
}
