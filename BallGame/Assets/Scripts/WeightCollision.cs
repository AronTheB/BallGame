using UnityEngine;
using UnityEngine.SceneManagement;

public class WeightCollision : MonoBehaviour
{
    public static int currentLives = 3;

    public Sprite[] lifeSprites;
    private SpriteRenderer sr;
    public bool isFinished = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kill"))
        {
            LoseLife();
            UpdateSprite();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            isFinished = true;
            // Mark level as completed and save time
        }
    }

    void LoseLife()
    {
        currentLives--;
        Debug.Log("Lives remaining: " + currentLives);

        if (currentLives <= 0)
        {
            Debug.Log("Resetting lives to 3");
            currentLives = 3;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void UpdateSprite()
    {
        if (lifeSprites.Length > currentLives && lifeSprites[currentLives] != null)
        {
            sr.sprite = lifeSprites[currentLives];
        }
    }

    
}