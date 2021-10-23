using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace Main.Scripts.PUN
{
    public class RoomElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _roomName;

        public RoomInfo RoomInfo { get; private set; }
        public void SetRoomInfo(RoomInfo roomInfo)
        {
            RoomInfo = roomInfo;
            _roomName.text = roomInfo.MaxPlayers + " | " + roomInfo.Name;
        }
    }
}