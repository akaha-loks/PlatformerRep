using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private Animator anim;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Fall();
    }
    
    private void Fall()
    {
        if(transform.position.y < -6)
        {
            Die();
        }
    }

    public void Die()
    {
        anim.SetBool("Death", true);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
