using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Button homeBtn, replayBtn;
    public Text levelText;

    void Start()
    {
        homeBtn.onClick.AddListener(() => {
            SoundManager.Instance.PlayClick();
            SceneManager.LoadScene(1);
        });

        replayBtn.onClick.AddListener(() => {
            SoundManager.Instance.PlayClick();
            SceneManager.LoadScene(2);
        });

        levelText.text = "" + PlayerPrefs.GetInt("CurrentLevel", 1);
    }
}

