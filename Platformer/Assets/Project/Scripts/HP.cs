using UnityEngine;

public class HP : MonoBehaviour
{
    public float HPCount = 100;
    [SerializeField] private Death die;

    private void Update()
    {
        if(HPCount <= 0)
        {
            die.Die();
            Destroy(gameObject, 3);
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    public void TakeDamage(float damage)
    {
        HPCount -= damage;
    }
}
