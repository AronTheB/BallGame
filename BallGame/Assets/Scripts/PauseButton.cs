using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseButtonUI;
    public GameObject pauseMenuUI;

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        pauseButtonUI.SetActive(false);
    }
    public void CloseMenu()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        pauseButtonUI.SetActive(true);
    }
}