using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    
    [SerializeField] private float speed;
    private bool lookingRight;

    [SerializeField] private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

    }

#region Move
    public void Move(float direction, bool isJumpButtonPressed)
    {
        if(isJumpButtonPressed)
            Jump();
        
        
        transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;
        
        CheckFlip(direction);
        
        if(direction != 0)
            anim.SetBool("Run", true);
        else
            anim.SetBool("Run", false);
    }
#endregion

    private void Jump()
    {
        if(Mathf.Abs(rb.velocity.y) < 0.05f)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

#region Flip
    private void CheckFlip(float direction)
    {
        if(direction < 0 && !lookingRight)
            Flip();
        else if(direction > 0 && lookingRight)
            Flip();
    }

    private void Flip()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        lookingRight = !lookingRight;
    }
#endregion
}
