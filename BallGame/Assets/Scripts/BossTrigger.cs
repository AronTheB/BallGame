using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public int myID;
    private TriggerManager manager;
    private bool hasTriggered = false;
    public Animator anim;

    void Start()
    {
        manager = GetComponentInParent<TriggerManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss") && !hasTriggered)
        {
            hasTriggered = true;
            manager.TriggerActivated(myID);
            anim.SetTrigger("AttackTrigger"); 
        }
    }
}