using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField]
    private TMP_Text volumeTextValue = null;
    [SerializeField]
    private Slider volumeSlider = null;
    [SerializeField]
    private float defaultVolume = 1.0f;
    [Header("Gameplay Settings")]
    [SerializeField]
    private TMP_Text ControllerSenTextValue = null;
    [SerializeField]
    private Slider ControllerSenSlider = null;
    [SerializeField]
    private int defaultSen = 4;
    public int mainControllerollerSen = 4;
    [Header("Toggle Settings")]
    [SerializeField]
    private Toggle invertYToggle = null;
    [Header("Graphics Settings")]
    [SerializeField]
    private Slider brightnessSlider = null;
    [SerializeField]
    private TMP_Text brightnessTextValue = null;
    [SerializeField]
    private float defaultbrightness = 1;

    [Space(15)]
    [SerializeField]
    private TMP_Dropdown qualityDropDown;
    [SerializeField]
    private Toggle fullScreenToggle;

    private int _qualityLevel;
    private bool _isFullScreen;
    private float _defaultBrightness = 1;
    private float _BrightnessLevel;
    [Header("Comfirmation")]
    [SerializeField]
    private GameObject comfimationPrompt = null;
    [Header("Levels To Load")]
    public string _newGameLevel;
    private string levelToLoad;
    [SerializeField]
    private GameObject nosavedGameDialog = null;

    [Header("Resolution dropdowns")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);

        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            nosavedGameDialog.SetActive(true);
        }
           
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        //volumeTextValue.text = volume.ToString("0.0");
        volumeTextValue.text = volume.ToString("0.0");
    }
    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }
    public void SetContorollerSen(float senzitivity)
    {
        mainControllerollerSen = Mathf.RoundToInt(senzitivity);
    }
    public void GameplayApply()
    {
        if (invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
            //invertYToggle y
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
            //invertYToggle x
        }
        PlayerPrefs.SetFloat("masterSen", mainControllerollerSen);
        StartCoroutine(ConfirmationBox());
    }

    public void SetBrightness(float brightness)
    {
       _BrightnessLevel = brightness;
        brightnessTextValue.text = brightness.ToString("0.0"); 
    }
    public void SetFullscreen(bool isfullscreen)
    {
        _isFullScreen = isfullscreen;
    }
    public void SetQuality(int  qualityIndex)
    {
        _qualityLevel = qualityIndex;
    }
    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", _BrightnessLevel);
        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);
        PlayerPrefs.SetInt("masterFullscreen", (_isFullScreen ? 1 : 0));
        Screen.fullScreen = _isFullScreen;
        StartCoroutine(ConfirmationBox());

    }

    public void ResetButton(string MenuType)
    {
        if (MenuType == "Graphics")
        {
            brightnessSlider.value = defaultbrightness;
            brightnessTextValue.text = defaultbrightness.ToString("0.0");
            qualityDropDown.value = 1;
            QualitySettings.SetQualityLevel(1);
            fullScreenToggle.isOn = false;
            Screen.fullScreen = false;
            Resolution currentResolution = Screen.currentResolution;
            Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
            resolutionDropdown.value = resolutions.Length;
            GraphicsApply();
        }
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
            VolumeApply();
        }
        if (MenuType == "Gameplay")
        {
            ControllerSenTextValue.text = defaultSen.ToString("0");
            ControllerSenSlider.value = defaultSen;
            invertYToggle.isOn = false;
            GameplayApply();
        }
        
    }
    public IEnumerator ConfirmationBox()
    {
        comfimationPrompt.SetActive(true);
        yield return new WaitForSeconds(0);
        comfimationPrompt.SetActive(false);
    }
}
