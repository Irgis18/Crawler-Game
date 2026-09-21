using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUi;

        [SerializeField] private Slider volumeSlider;

        [SerializeField] private TMP_Dropdown resolutionDropdown;

        [SerializeField] private Toggle fullScreenToggle;

        [SerializeField] private AudioMixer mixer;

        private Resolution[] resolutions;

        private int currentResoltionsID;

        private int currentResolutions; 


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Option()
    {
         //Initialiser
        resolutionDropdown.ClearOptions();
        resolutions = Screen.resolutions;

        List<string> _resolutionLabels = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            _resolutionLabels.Add(resolutions[i].ToString());
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) currentResolutions = i;
        }

        resolutionDropdown.AddOptions(_resolutionLabels);

        //Initier les valeurs
        resolutionDropdown.value = currentResolutions;
        fullScreenToggle.isOn = Screen.fullScreen;
        mixer.GetFloat("Master", out float volume);
        volumeSlider.value = Mathf.Pow(10f, volume / 20f);

        //Lier les evenenement
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        resolutionDropdown.onValueChanged.AddListener(UpdateResolution);
        fullScreenToggle.onValueChanged.AddListener(ToggleFullScreen);
    }

    private void UpdateVolume(float value)
    {
        value = Mathf.Clamp(value,0.0001f, 1f);
        mixer.SetFloat("Master", Mathf.Log10(value) * 20);
    }

    private void UpdateResolution(int _value)
    {
        currentResoltionsID = _value ;
        Screen.SetResolution(resolutions[currentResoltionsID].width, resolutions[currentResoltionsID].height, Screen.fullScreen);
        print("Resolution ID : " + _value);
    }

    private void ToggleFullScreen(bool _value)
    {
        print("Fullscreen : " + _value);
        Screen.fullScreen = _value;
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void LoadMainMenuButton()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
 
}
