using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Video UI Elements")]
    public Dropdown resolutionsDropdown;

    [Header("Audio UI Elements")]
    public Slider effectsSlider;
    public Slider musicSlider;
    public Text effectsPercent;
    public Text musicPercent;

    [Header("Audio Mixers")]
    public AudioMixer effectsMixer;
    public AudioMixer musicMixer;

    Resolution[] resolutions;

    void Start()
    {
        SetupResolutions();
    }

    void Update()
    {
        effectsPercent.text = (effectsSlider.value + 80) + "%";
        musicPercent.text = (musicSlider.value + 80) + "%";

        effectsMixer.SetFloat("Volume", effectsSlider.value);
        musicMixer.SetFloat("Volume", musicSlider.value);
    }

    void SetupResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();
        List<string> resOptions = new List<string>();
        int currentRes = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentRes = i;

            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRateRatio + "HZ";
            resOptions.Add(option);
        }
        resolutionsDropdown.AddOptions(resOptions);
        resolutionsDropdown.value = currentRes;
        resolutionsDropdown.RefreshShownValue();
    }

    public void ChangeResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetFullscreen(Toggle t)
    {
        if (t.isOn)
            Screen.fullScreen = true;
        else
            Screen.fullScreen = false;
    }
}
