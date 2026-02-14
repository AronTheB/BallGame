using UnityEngine;

public class CameraResizer : MonoBehaviour
{
    public float targetWidth = 8.5f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        AdjustCamera();
    }
    void LateUpdate()
    {
        AdjustCamera();
    }

    void AdjustCamera()
    {
        float aspectRatio = (float)Screen.width / Screen.height;
        float desiredSize = (targetWidth / aspectRatio) / 2f;

        cam.orthographicSize = desiredSize;
    }
}
