using Main.Scripts.Utils;
using UnityEngine;

namespace Main.Scripts.PUN
{
    public class CanvasManager : BaseInstance<CanvasManager>
    {
        [SerializeField] private BaseCanvas _createOrJoinRoomCanvas;
        [SerializeField] private BaseCanvas _currentRoomCanvas;

        public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas => _createOrJoinRoomCanvas as CreateOrJoinRoomCanvas;
        public CurrentRoomCanvas CurrentRoomCanvas => _currentRoomCanvas as CurrentRoomCanvas;

        private void Awake()
        {
            SetupCanvases();
        }

        private void SetupCanvases()
        {
            _createOrJoinRoomCanvas.Setup(this);
            _currentRoomCanvas.Setup(this);
        }

        public void ShowCreatedRoom(string roomName)
        {
            _createOrJoinRoomCanvas.Hide();
            
            CurrentRoomCanvas.SetRoomName(roomName);
            _currentRoomCanvas.Show();
        }

        public void ShowCreateOrJoinRoom()
        {
            _currentRoomCanvas.Hide();
            _createOrJoinRoomCanvas.Show();
        }
    }
}