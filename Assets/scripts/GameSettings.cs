using UnityEngine;

public static class GameSettings
{
    public static float PlayerSpeed = 5f;

    private const string SpeedKey = "PlayerSpeed";

    public static void Load()
    {
        PlayerSpeed = PlayerPrefs.GetFloat(SpeedKey, PlayerSpeed);
    }

    public static void Save()
    {
        PlayerPrefs.SetFloat(SpeedKey, PlayerSpeed);
        PlayerPrefs.Save();
    }
}