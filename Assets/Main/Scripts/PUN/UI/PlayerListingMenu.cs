using Photon.Pun;
using Photon.Realtime;

namespace Main.Scripts.PUN.UI
{
    public class PlayerListingMenu : BaseListingMenu<PlayerElement>
    {
        private void Awake()
        {
            GetCurrentRoomPlayers();
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            AddPlayerToList(newPlayer);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            var index = elements.FindIndex(x => x.Element == otherPlayer);

            if (index == -1) return;
            
            Destroy(elements[index].gameObject);
            elements.RemoveAt(index);
        }

        private void GetCurrentRoomPlayers()
        {
            foreach (var playerInfo in PhotonNetwork.CurrentRoom.Players)
            {
                AddPlayerToList(playerInfo.Value);
            }
        }

        private void AddPlayerToList(Player player)
        {
            var playerElement = Instantiate(elementPrefab, content);

            if (playerElement == null) return;
            
            playerElement.SetElementInfo(player);
            elements.Add(playerElement);
        }
    }
}
