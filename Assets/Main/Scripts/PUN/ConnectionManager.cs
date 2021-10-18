using Main.Main.Scripts.Managers;
using Photon.Pun;
using Photon.Realtime;

namespace Main.Main.Scripts.PUN
{
    public class ConnectionManager : MonoBehaviourPunCallbacks
    {
        void Start()
        {
            print("Connection to master");
            PhotonNetwork.NickName = MasterManager.Instance.GameSettings.NickName;
            PhotonNetwork.GameVersion = MasterManager.Instance.GameSettings.GameVersion;
            
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            print("Connected to master");
            print(PhotonNetwork.LocalPlayer.NickName);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            print($"Player has disconnect: {cause.ToString()}");
        }
    }
}
