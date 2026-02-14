using UnityEngine;

public class MovingTiles : MonoBehaviour
{
    public float speed = 2.0f;
    public float distance = 3.0f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float xOffset = Mathf.PingPong(Time.time * speed, distance) - (distance / 2f);
        transform.position = new Vector3(startPosition.x + xOffset, startPosition.y, startPosition.z);
    }
}
