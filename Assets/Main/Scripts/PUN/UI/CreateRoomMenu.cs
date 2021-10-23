using Photon.Pun;
using Photon.Realtime;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Scripts.PUN
{
    public class CreateRoomMenu : MonoBehaviourPunCallbacks
    {
        [BoxGroup("Room Setup"), SerializeField, Required] private Button _createRoomButton;
        [BoxGroup("Room Setup"), SerializeField, Required] private TextMeshProUGUI _roomName;

        private void Awake()
        {
            _createRoomButton.onClick.AddListener(OnRoomCreate);
        }

        private void OnRoomCreate()
        {
            Debug.Log("CreateButton has clicked");
            if (!PhotonNetwork.IsConnected) return;
            
            PhotonNetwork.JoinOrCreateRoom
            (
                _roomName.text,
                new RoomOptions
                {
                    MaxPlayers = 4
                },
                TypedLobby.Default
            );
        }

        public override void OnCreatedRoom()
        {
            Debug.Log($"{_roomName.text} has created", this);
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.Log($"{_roomName} creation has failed: {message}", this);
        }
    }
}
