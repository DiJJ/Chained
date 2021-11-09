using System.Collections.Generic;
using Main.Scripts.Interface;
using Photon.Pun;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Main.Scripts.PUN.UI
{
    public abstract class BaseListingMenu<T> : MonoBehaviourPunCallbacks, IBaseListingMenu<CanvasManager>
    {
        [BoxGroup("Room Listing Setup"), SerializeField, Required] protected Transform content;
        [BoxGroup("Room Listing Setup"), SerializeField, Required] protected T elementPrefab;

        protected List<T> elements = new List<T>();
        protected CanvasManager canvasManager;
        
        public void Setup(CanvasManager canvas)
        {
            canvasManager = canvas;
        }
    }
}