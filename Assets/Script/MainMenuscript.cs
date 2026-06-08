using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuscript : MonoBehaviour
{

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}