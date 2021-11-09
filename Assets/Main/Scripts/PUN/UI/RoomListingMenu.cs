using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

namespace Main.Scripts.PUN.UI
{
    public class RoomListingMenu : BaseListingMenu<RoomElement>
    {
        public override void OnJoinedRoom()
        {
            canvasManager.CreateOrJoinRoomCanvas.Hide();
            canvasManager.CurrentRoomCanvas.Show();
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            if (elementPrefab == null)
            {
                Debug.LogError($"Missing reference {elementPrefab}");
                return;
            }
            
            foreach (RoomInfo info in roomList)
            {
                if (info.RemovedFromList)
                {
                    var index = elements.FindIndex(x => x.Element.Name == info.Name);
                    Destroy(elements[index].gameObject);
                    elements.RemoveAt(index);
                    continue;
                }
                
                var room = Instantiate(elementPrefab, content);
                room.SetElementInfo(info);
                elements.Add(room);
            }
        }
    }
}
