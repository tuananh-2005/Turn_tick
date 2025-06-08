using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Transform pivot; // đối tượng quay
    public float rotationSpeed = 180f; // độ/giây
    private bool isRotating = false;
    private Vector3 rotationCenter;
    private float rotatedAngle = 0f;

    void Update()
    {
        if (!isRotating)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hit = Physics2D.OverlapPoint(clickPos);

                if (hit != null)
                {
                    var point = hit.GetComponent<PointBehavior>();
                    if (point == null || !point.isActive) return;

                    // Chỉ xử lý khi nhấn vào C, C', A', B'
                    if (point.pointType == PointType.C || point.pointType == PointType.CPrime
                        || point.pointType == PointType.APrime || point.pointType == PointType.BPrime)
                    {
                        rotationCenter = point.transform.position;
                        isRotating = true;
                        rotatedAngle = 0f;
                    }
                }
            }
        }
        else
        {
            // Xoay pivot quanh rotationCenter theo trục Z
            float deltaAngle = rotationSpeed * Time.deltaTime;
            pivot.RotateAround(rotationCenter, Vector3.forward, deltaAngle);
            rotatedAngle += deltaAngle;

            if (rotatedAngle >= 360f)
            {
                // Xoay đủ một vòng, dừng lại
                isRotating = false;
                Debug.Log("Xoay đủ 360 độ, dừng lại.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isRotating) return;

        var point = other.GetComponent<PointBehavior>();
        if (point != null)
        {
            // Khi pivot va chạm điểm khác thuộc các loại cần dừng
            if (point.pointType == PointType.C || point.pointType == PointType.CPrime
                || point.pointType == PointType.APrime || point.pointType == PointType.BPrime)
            {
                isRotating = false;
                Debug.Log("Pivot chạm vào điểm " + point.pointType + ", dừng xoay.");
            }
        }
    }
}




