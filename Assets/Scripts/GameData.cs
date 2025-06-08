using UnityEngine;

public static class GameData
{
    public static int totalLevel = 15;

    public static int GetLevelUnlocked()
    {
        return PlayerPrefs.GetInt("LevelUnlocked", 1);
    }

    public static void SetLevelUnlocked(int level)
    {
        if (level > GetLevelUnlocked())
            PlayerPrefs.SetInt("LevelUnlocked", level);
    }

    public static int GetScore()
    {
        return PlayerPrefs.GetInt("Score", 0);
    }

    public static void AddScore(int amount)
    {
        int newScore = GetScore() + amount;
        PlayerPrefs.SetInt("Score", newScore);
    }
}

