using Main.Scripts.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Main.Scripts.PUN
{
    public abstract class BaseCanvas : MonoBehaviour, IBaseCanvas<CanvasManager>
    {
        public CanvasManager CanvasManager { get; set; }
        
        public virtual void Setup(CanvasManager canvasManager)
        {
            CanvasManager = canvasManager;
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