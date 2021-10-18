using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Main
{
    public class ConnectionManager : MonoBehaviourPunCallbacks
    {
        // Start is called before the first frame update
        void Start()
        {
            print("Connection to master");
            
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            print("Connected to master");
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            print($"Player has disconnect: {cause.ToString()}");
        }
    }
}
