using UnityEngine;

public class MovingTilesVertical : MonoBehaviour
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
        float yOffset = Mathf.PingPong((Time.time * speed) + (distance / 2f), distance) - (distance / 2f);

        transform.position = new Vector3(startPosition.x, startPosition.y + yOffset, startPosition.z);
    }
}

