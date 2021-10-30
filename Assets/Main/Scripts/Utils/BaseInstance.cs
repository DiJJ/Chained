using UnityEngine;

namespace Main.Scripts.Utils
{
    public class BaseInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; set; }
    }
}