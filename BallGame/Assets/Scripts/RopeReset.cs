using UnityEngine;

public class RopeReset : MonoBehaviour
{
    public MouseAnchor mouseScript; // Drag the Yellow Anchor here in the Inspector
    private Vector3 anchorStartPosition;
    private Rigidbody2D[] allRopeParts;

    void Start()
    {
        anchorStartPosition = mouseScript.transform.position;
        // Collects every part of the rope hierarchy
        allRopeParts = mouseScript.transform.parent.GetComponentsInChildren<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kill"))
        {
            ResetRope();
        }
    }

    public void ResetRope()
    {
        // 1. Force the mouse script to "let go"
        mouseScript.isDragging = false;

        // 2. Calculate offset from current position to start
        Vector3 offset = anchorStartPosition - mouseScript.transform.position;

        // 3. Move everything and kill all momentum
        foreach (Rigidbody2D rb in allRopeParts)
        {
            rb.transform.position += offset;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0;
            
            // This "wakes up" the physics engine to the new position
            rb.Sleep(); 
            rb.WakeUp();
        }
        
        Debug.Log("Rope Reset and Ungrabbed!");
    }
}