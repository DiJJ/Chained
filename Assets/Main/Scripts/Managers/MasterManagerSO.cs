using Main.Scripts.Managers;
using UnityEngine;

namespace Main.Scripts.Managers
{
    [CreateAssetMenu(menuName = "SO/Singleton/Managers/Master Manager", fileName = "MasterManagerSO")]
    public class MasterManagerSO : SingletonScriptableObject<MasterManagerSO>
    {
        [SerializeField] private GameSettingsSO _gameSettingsSO;

        public static GameSettingsSO GameSettingsSO => Instance._gameSettingsSO;
    }
}
