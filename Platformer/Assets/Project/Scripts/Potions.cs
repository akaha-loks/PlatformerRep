using UnityEngine;

public class Potions : MonoBehaviour
{
    [SerializeField] private MovementPlayer move;
    [SerializeField] private HP hp;

    public void SpeedUp()
    {
        move.speed += 1;
        Destroy(gameObject);
    }
    
    public void HPUp()
    {
        hp.HPCount += 100;
        Destroy(gameObject);
    }
    
    public void JumpUp()
    {
        move.jumpForce = 4.3f;
        Destroy(gameObject);
    }
}
