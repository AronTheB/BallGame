using UnityEngine;

public class DestroyObsticles : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kill"))
        {
            Destroy(gameObject);
        }
    }
}
