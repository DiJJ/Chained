using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Main.Scripts.PUN
{
    public abstract class BaseElement<T> : MonoBehaviour
    {
        [BoxGroup("Element Setup"), SerializeField]
        protected TextMeshProUGUI elementName;
        
        public virtual T Element { get; protected set; }
        public abstract void SetElementInfo(T elementInfo);
    }
}