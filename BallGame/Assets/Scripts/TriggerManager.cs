using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public GameObject[] obstacles;

    public void TriggerActivated(int triggerID)
    {
        if (triggerID >= 0 && triggerID < obstacles.Length)
        {
            obstacles[triggerID].SetActive(true);
        }
    }
}