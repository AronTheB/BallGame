using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    public Animator anim;
    public ParticleSystem ps;
    public GameObject psObject;
    public GameObject boss;
    public GameObject sword;


    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ps.Play();
            sword.SetActive(false);
            anim.SetTrigger("DieTrigger"); 
            Destroy(boss, 1f);
            Destroy(psObject, 1f);
        }
    }
}