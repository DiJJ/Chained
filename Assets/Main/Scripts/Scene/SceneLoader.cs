using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main.Scripts.Scene
{
    public class SceneLoader : MonoBehaviour
    {
        private SceneManager _sceneManager;

        private void Awake()
        {
            SceneManager.LoadScene("_Main", LoadSceneMode.Additive);
        }
    }
}

