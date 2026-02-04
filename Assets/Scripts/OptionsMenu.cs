using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    [Header("Mouse Sensitivity")]
    public Slider sensitivitySlider;
    public TMP_Text sensitivityText;

    [Header("Audio Volume")]
    public Slider volumeSlider;
    public TMP_Text volumeText;

    private void Start()
    {
        float savedSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 2f);

        sensitivitySlider.value = savedSensitivity;
        UpdateSensitivityText(savedSensitivity);

        sensitivitySlider.onValueChanged.AddListener(OnSliderChanged);

        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 0.1f);

        volumeSlider.value = savedVolume;
        UpdateVolumeText(savedVolume);

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnSliderChanged(float value)
    {
        UpdateSensitivityText(value);

        PlayerPrefs.SetFloat("MouseSensitivity", value);
    }

    private void UpdateSensitivityText(float value)
    {
        sensitivityText.text = value.ToString("0.0");
    }

    private void OnVolumeChanged(float value)
    {
        UpdateVolumeText(value);

        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    private void UpdateVolumeText(float value)
    {
        if (volumeText != null)
            volumeText.text = Mathf.RoundToInt(value * 100) + "%";
    }
}
