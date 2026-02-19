using UnityEngine;

public static class GameSettings
{
    public static float BugSpeed = 5f;

    private const string SpeedKey = "BugSpeed";

    public static void Load()
    {
        BugSpeed = PlayerPrefs.GetFloat(SpeedKey, BugSpeed);
    }

    public static void Save()
    {
        PlayerPrefs.SetFloat(SpeedKey, BugSpeed);
        PlayerPrefs.Save();
    }
}
