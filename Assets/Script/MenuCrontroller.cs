using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null; //corriger avec IA j'ai mis TMP_text au lieu de TextMeshProUGUI
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private GameObject confirmationPromt = null;



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

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPromt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPromt.SetActive(false);
    }

}
