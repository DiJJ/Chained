using Main.Scripts.Managers;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Main.Scripts.PUN
{
    public class ConnectionManager : MonoBehaviourPunCallbacks
    {
        void Start()
        {
            Debug.Log("Connecting to master", this);

            PhotonNetwork.NickName = MasterManagerSO.GameSettingsSO.NickName;
            PhotonNetwork.GameVersion = MasterManagerSO.GameSettingsSO.GameVersion;
            
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to master", this);
            Debug.Log($"Player's nickname is: {PhotonNetwork.LocalPlayer.NickName}", this);

            if (!PhotonNetwork.InLobby) PhotonNetwork.JoinLobby();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($"Player has disconnect: {cause.ToString()}", this);
        }
    }
}
