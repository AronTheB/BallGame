using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WeightCollision : MonoBehaviour
{
    public static int currentLives = 3;

    public static int attemptCounter = 1;
    public TextMeshProUGUI attemptText;

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
            if (collision.gameObject.CompareTag("Finish"))
            {
                isFinished = true;

                string sceneName = SceneManager.GetActiveScene().name;
                string levelNumStr = sceneName.Replace("Level ", "");

                if (int.TryParse(levelNumStr, out int currentLevelNum))
                {
                    int nextLevel = currentLevelNum + 1;
                    PlayerPrefs.SetInt("Level" + nextLevel + "Unlocked", 1);
                    PlayerPrefs.Save();

                    Debug.Log("Unlocked Level " + nextLevel);
                }

                SceneManager.LoadScene("LevelSelector");
            }
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