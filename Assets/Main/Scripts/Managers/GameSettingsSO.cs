using UnityEngine;

namespace Main.Scripts.Managers
{
    [CreateAssetMenu(menuName = "SO/Singleton/Managers/Game Settings", fileName = "GameSettingsSO")]
    public class GameSettingsSO : ScriptableObject
    {
        [SerializeField] private string _gameVersion = "0.0.0";
        [SerializeField] private string _nickName = "Kek";
        
        public string GameVersion => _gameVersion;

        public string NickName
        {
            get
            {
                int value = Random.Range(0, 9999);
                return _nickName + value;
            }
        }
    }
}
