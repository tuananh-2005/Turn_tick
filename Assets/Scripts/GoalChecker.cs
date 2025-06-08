using UnityEngine;
using System.Linq;

public class GoalChecker : MonoBehaviour
{
    public GameObject winPanel, losePanel;
    public float distanceThreshold = 0.5f;

    Transform pointA, pointB, targetA, targetB;

    void Start()
    {
        var points = FindObjectsOfType<PointBehavior>();

        pointA = points.FirstOrDefault(p => p.pointType == PointType.A)?.transform;
        pointB = points.FirstOrDefault(p => p.pointType == PointType.B)?.transform;
        targetA = points.FirstOrDefault(p => p.pointType == PointType.APrime)?.transform;
        targetB = points.FirstOrDefault(p => p.pointType == PointType.BPrime)?.transform;

        if (pointA == null || pointB == null || targetA == null || targetB == null)
        {
            Debug.LogError("❌ Thiếu điểm A, B, A' hoặc B'. Kiểm tra PointBehavior và PointType!");
        }
    }

    void Update()
    {
        if (pointA == null || pointB == null || targetA == null || targetB == null) return;

        bool isAPointClose = Vector2.Distance(pointA.position, targetA.position) <= distanceThreshold;
        bool isBPointClose = Vector2.Distance(pointB.position, targetB.position) <= distanceThreshold;

        if (isAPointClose && isBPointClose)
        {
            Debug.Log("✅ Cả 2 điểm A và B đều chạm mục tiêu, WIN!");
            if (winPanel != null) winPanel.SetActive(true);
            Time.timeScale = 0;

            SoundManager.Instance?.PlayWin();
            GameData.AddScore(10);
            UnlockNextLevel();
        }
    }

    void UnlockNextLevel()
    {
        int cur = PlayerPrefs.GetInt("CurrentLevel", 1);
        GameData.SetLevelUnlocked(cur + 1);
    }
}



