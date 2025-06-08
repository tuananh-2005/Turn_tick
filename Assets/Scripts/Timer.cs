using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f;
    public Text timerText;
    public GameObject losePanel;
    public bool useTimer = true;

    void Update()
    {
        if (!useTimer) return;

        timeLimit -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.CeilToInt(timeLimit);

        if (timeLimit <= 0)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
            SoundManager.Instance.PlayLose();
        }
    }
}

