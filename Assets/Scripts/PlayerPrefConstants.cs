using UnityEngine;

public static class PlayerPrefConstants
{
    public const string Level = "level";
    public const string Health = "health";

    public const string ShotDamage = "damage";
    public const string ShotSpeed = "shot_speed";
    public const string ShotLifeTime = "shot_life_time";

    public const string PlayerSpeed = "player_speed";
    public const string PlayerFireRate = "player_fire_rate";
}

public static class StaticData
{
    public static void ResetData()
    {
        PlayerPrefs.SetInt(PlayerPrefConstants.Level, 1);
        PlayerPrefs.SetInt(PlayerPrefConstants.Health, -1);
        PlayerPrefs.SetFloat(PlayerPrefConstants.ShotDamage, 0);
        PlayerPrefs.SetFloat(PlayerPrefConstants.ShotSpeed, 0);
        PlayerPrefs.SetFloat(PlayerPrefConstants.ShotLifeTime, 0);
        PlayerPrefs.SetFloat(PlayerPrefConstants.PlayerSpeed, 0);
        PlayerPrefs.SetFloat(PlayerPrefConstants.PlayerFireRate, 0);
    }
}