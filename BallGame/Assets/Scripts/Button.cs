using UnityEngine;

public class BallButton : MonoBehaviour
{
    private bool isPressed = false;
    private ButtonManager manager;
    public Sprite pressedSprite;
    private GameObject lightEffect;

    void Start()
    {
        manager = Object.FindFirstObjectByType<ButtonManager>();
        lightEffect = transform.GetChild(0).gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;
            GetComponent<SpriteRenderer>().sprite = pressedSprite;
            manager.ButtonActivated();
            lightEffect.SetActive(false);
        }
    }
}
