using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private SceneManager _sceneManager;

    private void Awake()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
    }
}
