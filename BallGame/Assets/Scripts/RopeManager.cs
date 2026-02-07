using UnityEngine;

public class RopeManager : MonoBehaviour
{
    public GameObject ropePrefab;
    public Transform spawnPoint;
    private GameObject currentRope;

    void Start()
    {
        SpawnNewRope();
    }

    public void Respawn()
    {
        MouseAnchor oldAnchor = currentRope.GetComponentInChildren<MouseAnchor>();
        if (oldAnchor != null) oldAnchor.isDragging = false;
        Destroy(currentRope);
        SpawnNewRope();
    }

    void SpawnNewRope()
    {
        currentRope = Instantiate(ropePrefab, spawnPoint.position, Quaternion.identity);
        MouseAnchor newAnchor = currentRope.GetComponentInChildren<MouseAnchor>();
        newAnchor.isDragging = false;
    }
}


