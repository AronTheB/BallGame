using UnityEngine;

public class RopeAnchor : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 moveAmount = moveInput.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveAmount);
    }
}