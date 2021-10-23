using Main.Scripts.Managers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Main
{
    public class SingletonReferences : MonoBehaviour
    {
        [SerializeField, Required] private MasterManagerSO _masterManagerSO;
    }
}
