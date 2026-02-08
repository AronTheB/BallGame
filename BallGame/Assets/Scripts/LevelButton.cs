using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class LevelButton : MonoBehaviour
{

    public int level;
    public TextMeshProUGUI levelText;
    public static string currentopenedLevel;
    private UnityEngine.UI.Button btn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        btn = GetComponent<UnityEngine.UI.Button>();
        levelText.text = level.ToString();

        if (level == 1) PlayerPrefs.SetInt("Level1Unlocked", 1);

        int isUnlocked = PlayerPrefs.GetInt("Level" + level + "Unlocked", 0);

        if (isUnlocked == 1)
        {
            btn.interactable = true;
        }
        else
        {
            btn.interactable = false;
            levelText.alpha = 0.5f; // Visual feedback for locked
        }
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + level.ToString());
        currentopenedLevel = "Level " + level.ToString();
    }
}
