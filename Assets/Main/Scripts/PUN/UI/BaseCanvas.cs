using Main.Scripts.Interface;
using UnityEngine;

namespace Main.Scripts.PUN
{
    public abstract class BaseCanvas : MonoBehaviour, IBaseCanvas<CanvasManager>
    {
        [SerializeField] private CreateRoomMenu _createRoomMenu;
        
        public CanvasManager CanvasManager { get; set; }
        
        public void Setup(CanvasManager canvasManager)
        {
            CanvasManager = canvasManager;
            _createRoomMenu.Setup(canvasManager);
        }

        public virtual void Show()
        {
            this.gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            this.gameObject.SetActive(false);
        }
    }
}