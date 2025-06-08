using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MenuUI : MonoBehaviour
{
    public Button playButton, helpButton, closeHelpButton;
    public CanvasGroup helpPanel;

    void Start()
    {
        playButton.onClick.AddListener(OnPlayClicked);
        helpButton.onClick.AddListener(OnHelpClicked);
        closeHelpButton.onClick.AddListener(OnCloseHelpClicked);

        helpPanel.gameObject.SetActive(false);
    }

    public void OnPlayClicked()
    {
        SoundManager.Instance.PlayClick();
        SceneManager.LoadScene(1);
    }

    public void OnHelpClicked()
    {
        SoundManager.Instance.PlayClick();
        helpPanel.gameObject.SetActive(true);
        helpPanel.alpha = 0;
        helpPanel.DOFade(1f, 0.5f);
    }

    public void OnCloseHelpClicked()
    {
        SoundManager.Instance.PlayClick();
        helpPanel.DOFade(0f, 0.5f).OnComplete(() => helpPanel.gameObject.SetActive(false));
    }

    public void OnButtonAClicked()
    {
        SoundManager.Instance.PlayClick();
        SceneManager.LoadScene(1);
    }

    public void OnButtonBClicked()
    {
        SoundManager.Instance.PlayClick();
    }

    public void OnNextLevelClicked()
    {
        SoundManager.Instance.PlayClick();
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        PlayerPrefs.SetInt("CurrentLevel", currentLevel + 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


