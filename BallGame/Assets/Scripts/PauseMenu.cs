using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public PauseButton pauseButton;


    
    public void Resume()
    {
        pauseButton.CloseMenu();
    }

    public void Settings()
    {
        // Nothing here yet
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelector");
    }

}
