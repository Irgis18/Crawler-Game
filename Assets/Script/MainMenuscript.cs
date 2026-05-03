using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuscript : MonoBehaviour
{
    private Button button;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Option()
    {
        if(Button)
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
