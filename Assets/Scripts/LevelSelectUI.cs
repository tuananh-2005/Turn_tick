using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelSelectUI : MonoBehaviour
{
    public Button[] levelButtons; // Gắn đủ 15 nút
    public Button viewScoreButton, closeScoreButton, homeButton;
    public CanvasGroup scorePanel;
    public Text scoreText;

    void Start()
    {
        int unlocked = GameData.GetLevelUnlocked();

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1;
            bool unlockedState = levelIndex <= unlocked;

            levelButtons[i].interactable = unlockedState;
            levelButtons[i].onClick.AddListener(() =>
            {
                SoundManager.Instance.PlayClick();
                PlayerPrefs.SetInt("CurrentLevel", levelIndex); // lưu để dùng ở scene 2
                SceneManager.LoadScene(2);
            });
        }

        viewScoreButton.onClick.AddListener(ShowScore);
        closeScoreButton.onClick.AddListener(HideScore);
        homeButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.PlayClick();
            SceneManager.LoadScene(0);
        });

        scorePanel.gameObject.SetActive(false);

    }

    void ShowScore()
    {
        SoundManager.Instance.PlayClick();
        scoreText.text = "Điểm: " + GameData.GetScore();
        scorePanel.gameObject.SetActive(true);
        scorePanel.alpha = 0;
        scorePanel.DOFade(1f, 0.5f);
    }

    void HideScore()
    {
        SoundManager.Instance.PlayClick();
        scorePanel.DOFade(0f, 0.5f).OnComplete(() => scorePanel.gameObject.SetActive(false));
    }
}
