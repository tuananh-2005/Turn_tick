using UnityEngine;

public enum PointType { A, B, APrime, BPrime, C, CPrime, D }

public class PointBehavior : MonoBehaviour
{
    public PointType pointType;
    public bool isActive = true;
}
