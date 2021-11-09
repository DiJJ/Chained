using System;
using Photon.Pun;
using Photon.Realtime;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Scripts.PUN
{
    public class RoomElement : BaseElement<RoomInfo>
    {
        [BoxGroup("Room Element Setup"), SerializeField, Required]
        private Button _joinRoomButton;

        private void Start()
        {
            _joinRoomButton.onClick.AddListener(OnRoomCreated);
        }

        public override void SetElementInfo(RoomInfo elementInfo)
        {
            Element = elementInfo;
            elementName.text = elementInfo.MaxPlayers + " | " + elementInfo.Name;        
        }

        private void OnRoomCreated()
        {
            PhotonNetwork.JoinRoom(Element.Name);
        }
    }
}