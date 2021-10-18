using UnityEngine;

namespace Main.Main.Scripts.Managers
{
    [CreateAssetMenu(menuName = "SO/Singleton/Managers/Master Manager", fileName = "MasterManagerSO")]
    public class MasterManager : SingletonScriptableObject<MasterManager>
    {
        [SerializeField] private GameSettings _gameSettings;

        public GameSettings GameSettings => Instance._gameSettings;
    }
}
