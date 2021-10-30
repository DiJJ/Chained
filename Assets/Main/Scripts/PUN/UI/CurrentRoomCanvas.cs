using TMPro;
using UnityEngine;

namespace Main.Scripts.PUN
{
    public class CurrentRoomCanvas : BaseCanvas
    {
        [SerializeField] private TextMeshProUGUI _roomName;

        public void SetRoomName(string roomName)
        {
            _roomName.text = roomName;
        }
    }
}