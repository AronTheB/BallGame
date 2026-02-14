using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public int totalButtons;
    private int currentPressed = 0;

    public GameObject[] doors;

    public void ButtonActivated()
    {
        currentPressed++;

        if (currentPressed >= totalButtons)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(false);
        }
    }
}