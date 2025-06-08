using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] levelPrefabs;

    void Start()
    {
        int levelIndex = PlayerPrefs.GetInt("CurrentLevel", 1);
        levelIndex = Mathf.Clamp(levelIndex, 1, levelPrefabs.Length);
        Instantiate(levelPrefabs[levelIndex - 1]);
    }
}

