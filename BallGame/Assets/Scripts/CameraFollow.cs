using UnityEngine;

public class CameraClimb : MonoBehaviour
{
    public float draggingSpeed;
    public float notDraggingSpeed;

    private MouseAnchor anchorScript;
    private WeightCollision weightCollision;

    void Start()
    {
        anchorScript = Object.FindFirstObjectByType<MouseAnchor>();
        weightCollision = Object.FindFirstObjectByType<WeightCollision>();
    }

    void Update()
    {
        if (anchorScript.isDragging && weightCollision.isFinished == false)
        {
            transform.Translate(Vector3.up * draggingSpeed * Time.deltaTime);
        }
        if (anchorScript.isStarted && anchorScript.isDragging == false && weightCollision.isFinished == false)
        {
            transform.Translate(Vector3.up * notDraggingSpeed * Time.deltaTime);
        }
        if (weightCollision.isFinished)
        {
            transform.Translate(Vector3.up * 0 * Time.deltaTime);
        }
    }
}

