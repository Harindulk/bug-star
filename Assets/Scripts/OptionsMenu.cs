using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer VolumeMixer;
    public Slider VolumeSlider;

    public Dropdown QualityDropDown;

    public Dropdown ResolutionDropDown;


    public Dropdown ScreenMode;

    Resolution[] resolutions;

    const string prefName = "optionsvalue";
    const string resName = "resolutionoption";

    private void Awake()
    {
        ResolutionDropDown.onValueChanged.AddListener(new UnityAction<int>(index =>
       {
           PlayerPrefs.SetInt(resName, ResolutionDropDown.value);
           PlayerPrefs.Save();
       }));

        QualityDropDown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(prefName, QualityDropDown.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("MVolume", 1f);
        VolumeMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));

        QualityDropDown.value = PlayerPrefs.GetInt(prefName, 3);

        resolutions = Screen.resolutions;

        ResolutionDropDown.ClearOptions();


        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "X" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }
        ResolutionDropDown.AddOptions(options);
        ResolutionDropDown.value = PlayerPrefs.GetInt(resName, currentResolutionIndex);
        ResolutionDropDown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ChangeVol(float volume)
    {
        PlayerPrefs.SetFloat("MVolume",volume);
        VolumeMixer.SetFloat("volume", PlayerPrefs.GetFloat("Mvolume"));
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        if (isFullScreen == false)
        {
            PlayerPrefs.SetInt("togglestate", 0);
        }
        else
        {
            isFullScreen = true;
            PlayerPrefs.SetInt("togglestate", 1);
        }
    }
}
