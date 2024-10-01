using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float damage = 50f;

    private MovementPlayer move;
    private float lastSpeed;

    [SerializeField] private float attackRate = 3f;
    private float nextAttackTime = 0f;

    private void Awake()
    {
        move = GetComponent<MovementPlayer>();
        lastSpeed = move.speed;
    }

    public void Attack(bool attackButtonDown)
    {
        if(Time.time >= nextAttackTime)
        {
            if(attackButtonDown)
            {
                anim.SetTrigger("Attack");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
                foreach(Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<HP>().TakeDamage(damage);
                }
                nextAttackTime = Time.time + 3f / attackRate;
            } 
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
