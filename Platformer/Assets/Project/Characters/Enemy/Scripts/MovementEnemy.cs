using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    public float speed = 4;
    [SerializeField] private float angrySpeed = 6;
    [SerializeField] private float chillSpeed = 4;

    [SerializeField] private int positionOfPatrol = 5;
    [SerializeField] private Transform point;

    [SerializeField] private AttackEnemy attack;

    bool movingRight;

    [SerializeField] private Transform player;
    public float stoppingDistance = 10;

    bool chill = false;
    bool angry = false;
    bool goBack = false;

    private void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }
        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            GoBack();
        }
    }
    
    private void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            movingRight = true;
        }
        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - Time.deltaTime, transform.position.y);
        }
    }
    
    private void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = angrySpeed;
        attack.Attack();
    }
    
    private void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        speed = chillSpeed;
    }
}
