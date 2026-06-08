using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using System.Collections.Generic;
using Unity.VisualScripting;
public class Option : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    [SerializeField] private TMP_Dropdown resolutionDropdown;

    [SerializeField] private Toggle fullScreenToggle;

    [SerializeField] private AudioMixer mixer;

    private Resolution[] resolutions;

    private int currentResoltionsID;

    private int currentResolutions; 

    private void Awake()
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
        mixer.GetFloat("Master", out float _volume);
        volumeSlider.value = Mathf.InverseLerp(-100f, 5f, _volume);

        //Lier les evenenement
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        resolutionDropdown.onValueChanged.AddListener(UpdateResolution);
        fullScreenToggle.onValueChanged.AddListener(ToggleFullScreen);
    }

    private void UpdateVolume(float _value)
    {
        print("Audio Volume : " + _value);
        mixer.SetFloat("Master", Mathf.Lerp(-100, 0, _value));
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

}
