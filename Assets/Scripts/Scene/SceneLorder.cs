using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string loadScene;

    public void SceneChange()
    {
        SceneManager.LoadScene(loadScene);
    }
}