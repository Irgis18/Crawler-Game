using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuscript : MonoBehaviour
{

    public void StartGame(string sceneName)
    {
        PlayerPrefs.DeleteKey("Money");
        PlayerPrefs.DeleteKey("Attack");
        PlayerPrefs.DeleteKey("Speed");
        PlayerPrefs.DeleteKey("MaxHP");
        PlayerPrefs.DeleteKey("HP");
        PlayerPrefs.Save();

        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}