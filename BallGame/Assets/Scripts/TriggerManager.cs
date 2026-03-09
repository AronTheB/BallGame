using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public float destroyDelay = 20f;

    public void TriggerActivated(int triggerID)
    {
        if (triggerID >= 0 && triggerID < obstacles.Length)
        {
            obstacles[triggerID].SetActive(true);
            Destroy(obstacles[triggerID], destroyDelay);
        }
    }
}