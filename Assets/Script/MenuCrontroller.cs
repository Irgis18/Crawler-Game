using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCrontroller : MonoBehaviour
{
    [Header("Levels To Load")]
    public string newgamelvl;
    private string lvlToload;
    [SerializeField] private GameObject noSavedGameDialog = null;

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(newgamelvl);
    }

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            lvlToload = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(lvlToload);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
