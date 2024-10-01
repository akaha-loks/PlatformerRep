using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask playerLayers;
    [SerializeField] private float damage = 20f;

    [SerializeField] private float attackRate = 3f;
    private float nextAttackTime = 0f;

    private MovementEnemy move;
    
    private void Awake()
    {
        move = GetComponent<MovementEnemy>();
    }
    
    public void Attack()
    {
        if(Time.time >= nextAttackTime)
        {
            anim.SetTrigger("Attack");
            Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
            foreach(Collider2D player in hit)
            {
                player.GetComponent<HP>().TakeDamage(damage);
            }
            nextAttackTime = Time.time + 3f / attackRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
