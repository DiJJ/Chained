using Main.Scripts.PUN.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Main.Scripts.PUN
{
    public class CreateOrJoinRoomCanvas : BaseCanvas
    {
        [SerializeField, Required] private CreateRoomMenu _createRoomMenu;
        [SerializeField, Required] private RoomListingMenu _roomListingMenu;

        public override void Setup(CanvasManager canvasManager)
        {
            base.Setup(canvasManager);
            _createRoomMenu.Setup(canvasManager);
            _roomListingMenu.Setup(canvasManager);
        }
    }
}