using UnityEngine;

[RequireComponent(typeof(MovementPlayer))]
[RequireComponent(typeof(PlayerAttack))]

public class InputPlayer : MonoBehaviour
{
    private MovementPlayer playerMovement;
    private PlayerAttack playerAttack;
    private Animator anim;

    private void Awake()
    {
        playerMovement = GetComponent<MovementPlayer>();
        playerAttack = GetComponent<PlayerAttack>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontalDirection = Input.GetAxisRaw(GlobalStringVars.HORIZONTAL_AXIS);
        bool attackButtonDown = Input.GetButtonDown(GlobalStringVars.ATTACK);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);

        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
        playerAttack.Attack(attackButtonDown);
    }
}
