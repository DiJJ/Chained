using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main.Scripts.Scene
{
    public class SceneLoader : MonoBehaviour
    {
        [BoxGroup("Scene Loader Settings"), SerializeField] private string _sceneName = "_Main";
        [BoxGroup("Scene Loader Settings"), SerializeField] private LoadSceneMode _loadSceneMode = LoadSceneMode.Additive;
        
        private void Awake()
        {
            LoadScene(_sceneName, _loadSceneMode);
        }

        private void LoadScene(string sceneName, LoadSceneMode loadSceneMode)
        {
            SceneManager.LoadScene(sceneName, loadSceneMode);
        }
    }
}

