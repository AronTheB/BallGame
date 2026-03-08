using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    private TriggerManager manager;
    public Animator anim;
    public ParticleSystem ps;
    public GameObject boss;


    void Start()
    {
        manager = GetComponentInParent<TriggerManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            ps.Play();
            anim.SetTrigger("DieTrigger"); 
            Destroy(boss, 1f);
        }
        Destroy(gameObject);
    }
}