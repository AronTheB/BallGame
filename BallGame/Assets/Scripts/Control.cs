using UnityEngine;

public class MouseAnchor : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera cam;
    public bool isDragging = false;
    public bool isStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        cam = Object.FindFirstObjectByType<Camera>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector2 inputPos = GetWorldInputPosition();
            Collider2D hitCollider = Physics2D.OverlapPoint(inputPos);

            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                isDragging = true;
                isStarted = true;
            }
        }

        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)))
        {
            isDragging = false;
            rb.linearVelocity = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 worldPos = GetWorldInputPosition();
            rb.MovePosition(worldPos);
        }
    }

    Vector3 GetWorldInputPosition()
    {
        Vector3 screenPos;

        if (Input.touchCount > 0)
        {
            screenPos = Input.GetTouch(0).position;
        }
        else
        {
            screenPos = Input.mousePosition;
        }

        float zDist = Mathf.Abs(cam.transform.position.z - transform.position.z);
        screenPos.z = zDist > 0 ? zDist : 10f;

        return cam.ScreenToWorldPoint(screenPos);
    }
}