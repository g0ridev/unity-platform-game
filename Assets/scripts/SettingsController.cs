using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour
{
    public Slider speedSlider;
    public TextMeshProUGUI speedValueText;

    public float minSpeed = 1f;
    public float maxSpeed = 4f;

    void Start()
    {
        GameSettings.Load();

        speedSlider.minValue = minSpeed;
        speedSlider.maxValue = maxSpeed;

        speedSlider.value = GameSettings.BugSpeed;
        UpdateText(speedSlider.value);

        speedSlider.onValueChanged.AddListener(OnSpeedChanged);
    }

    public void OnSpeedChanged(float newSpeed)
    {
        GameSettings.BugSpeed = newSpeed;
        GameSettings.Save();
        UpdateText(newSpeed);
    }

    void UpdateText(float value)
    {
        if (speedValueText != null)
            speedValueText.text = $"Speed: {value:0.0}";
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
