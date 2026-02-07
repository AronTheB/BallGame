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
        if (cam == null) cam = Object.FindFirstObjectByType<Camera>();
        rb.gravityScale = 0;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseRay = cam.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hitCollider = Physics2D.OverlapPoint(mouseRay);
            Debug.Log("Hit collider");

            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                isDragging = true;
                isStarted = true;
                Debug.Log("Dragging True");

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            rb.linearVelocity = Vector2.zero; 
        }
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 mousePos = Input.mousePosition;
            float zDist = Mathf.Abs(cam.transform.position.z - transform.position.z);
            mousePos.z = zDist > 0 ? zDist : 10f;

            Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);
            rb.MovePosition(worldPos);
        }
    }
}