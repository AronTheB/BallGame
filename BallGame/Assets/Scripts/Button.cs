using UnityEngine;

public class BallButton : MonoBehaviour
{
    private bool isPressed = false;
    private ButtonManager manager;
    public Sprite pressedSprite;

    void Start()
    {
        manager = Object.FindFirstObjectByType<ButtonManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;
            GetComponent<SpriteRenderer>().sprite = pressedSprite;
            manager.ButtonActivated();
        }
    }
}
